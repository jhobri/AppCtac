using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Back.Ctac.Api.Extensions;
using Back.Ctac.Api.Middleware;
using Back.Ctac.Api.Modules;
using Back.Ctac.Map;
using Back.Ctac.Rest.Service.Fruta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Minedu.Fw.General.Models.Configurations;
using Minedu.Fw.General.Request.Header;
using Minedu.Fw.Security.Jwt;
using Minedu.Fw.Security.Jwt.Models;



namespace Back.Ctac.Api;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        JwtRsaConfiguration = Configuration.GetSection(nameof(JwtRsaConfiguration)).Get<JwtRsaConfiguration>();
        RequestConfiguration = Configuration.GetSection(nameof(RequestConfiguration)).Get<RequestConfiguration>();
        SoaEndpointConfiguration = Configuration.GetSection(nameof(SoaEndpointConfiguration)).Get<SoaEndpointConfiguration>();
        SecurityCentralConfiguration = Configuration.GetSection(nameof(SecurityCentralConfiguration)).Get<SecurityCentralConfiguration>();
        GlobalConfiguration = Configuration.GetSection(nameof(GlobalConfiguration)).Get<GlobalConfiguration>();
        MsaAppDevModeConfiguration = Configuration.GetSection(nameof(MsaAppDevModeConfiguration)).Get<MsaAppDevModeConfiguration>();
        QueueConfiguration = Configuration.GetSection(nameof(QueueConfiguration)).Get<QueueConfiguration>();
        _env = env;
    }

    private readonly string swaggerBasePath = "docs/specification";
    public JwtRsaConfiguration JwtRsaConfiguration { get; }
    public RequestConfiguration RequestConfiguration { get; }
    public IConfiguration Configuration { get; }
    public SoaEndpointConfiguration SoaEndpointConfiguration { get; }
    public SecurityCentralConfiguration SecurityCentralConfiguration { get; }
    public GlobalConfiguration GlobalConfiguration { get; }
    public MsaAppDevModeConfiguration MsaAppDevModeConfiguration { get; }
    public QueueConfiguration QueueConfiguration { get; }
    private readonly IWebHostEnvironment _env;

    public virtual IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.Configure<JwtRsaConfiguration>(Configuration.GetSection(nameof(JwtRsaConfiguration)));
        services.Configure<RequestConfiguration>(Configuration.GetSection(nameof(RequestConfiguration)));
        services.Configure<SoaEndpointConfiguration>(Configuration.GetSection(nameof(SoaEndpointConfiguration)));
        services.Configure<SecurityCentralConfiguration>(Configuration.GetSection(nameof(SecurityCentralConfiguration)));
        services.Configure<QueueConfiguration>(Configuration.GetSection(nameof(QueueConfiguration)));
        services.Configure<GlobalConfiguration>(Configuration.GetSection(nameof(GlobalConfiguration)));
        services.Configure<MsaAppDevModeConfiguration>(Configuration.GetSection(nameof(MsaAppDevModeConfiguration)));

        #region Versionamiento Api

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        //services.AddSwaggerGen();

        #endregion Versionamiento Api

        #region temporal

        JwtSiagieMsaConfigurations(services);
        JwtPadronConfigurations(services);

        #endregion temporal

        services.AddCustomMvc();
        services.AddCustomSwagger();
        services.AddCustomSecuritySwagger();
        services.AddCustomApiController();
        services.AddFluent();
        services.AddCustomIntegrations(SoaEndpointConfiguration);
        services.AddOptions();

        #region External Apis      
        services.AddRestCustomClient<IFrutaApiGateway>("gateway-fruta");

        #endregion External Apis

        #region Rabbit
        /*
        var RabbitSettingSection = Configuration.GetSection("QueueConfiguration");
        var RabbitConfig = RabbitSettingSection.Get<QueueConfiguration>();

        services.AddMassTransit(x =>
        {
            //x.AddConsumer<InstitucionEducativaSeccionGrabacionIntegrationConsumer>();
            //x.AddConsumer<InstitucionEducativaSeccionEliminacionIntegrationConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri(RabbitConfig.HostName), h =>
                {
                    h.Username(RabbitConfig.UserName);
                    h.Password(RabbitConfig.Password);
                });
                
            }));
        });

         services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            //   options.StopTimeout = TimeSpan.FromMinutes(1);
        });
        

        services.AddHttpContextAccessor();
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedForHeaderName = "X-Coming-From";
        });
        */

        #endregion Rabbit

        #region AutoMap

        var mappingConfig = new MapperConfiguration(mc =>
        {

            mc.AddProfile(new AreaMap());
            mc.AddProfile(new GradoMap());
            mc.AddProfile(new EstudianteMap());
            mc.AddProfile(new ResponsableEvaluacionMap());
            mc.AddProfile(new IeEvaluacionMap());
            mc.AddProfile(new EnumeradoMap());


        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        #endregion AutoMap

        var container = new ContainerBuilder();
        container.Populate(services);

        container.RegisterModule(new MediatorModule());
        container.RegisterModule(new QueryModule(Configuration["ConnectionStrings:SiagieQuery"]));
        container.RegisterModule(new CommandModule(Configuration["ConnectionStrings:SiagieCommand"]));
        // container.RegisterModule(new CommandModule(Configuration["ConnectionStrings:SiagieCommand2_20"]));

        return new AutofacServiceProvider(container.Build());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
    {
        var pathBase = Configuration["PATH_BASE"];
        if (!string.IsNullOrEmpty(pathBase))
        {
            app.UsePathBase(pathBase);
        }

        app.UseSwagger(c =>
        {
            c.RouteTemplate = swaggerBasePath + "/{documentName}/swagger.json";
        });
        app.UseSwaggerUI(
            options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/{swaggerBasePath}/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = $"{swaggerBasePath}";
                    options.InjectStylesheet($"/swagger-ui/custom.css");
                    options.InjectJavascript($"/swagger-ui/custom.js", "text/javascript");
                    options.DocumentTitle = "Evaluación API ::SIAGIE::";
                }
            });

        app.UseRouting();
        app.UseCors("CorsPolicy");
        ConfigureAuth(app);

        app.UseMiddleware<ASymmetricRsaJwtMiddleware>();
        app.UseMiddleware<HttpCustomMiddleware>();
        app.UseMiddleware<BindRequestMiddleware>();
        app.UseForwardedHeaders();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
        });
    }

    protected virtual void ConfigureAuth(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public void JwtSiagieMsaConfigurations(IServiceCollection services)
    {
        var rsaKeyName = Configuration.GetSection("JwtSiagieMsaConfiguration:rsaPrivateName").Value;
        var rsaLocalFolder = Configuration.GetSection("JwtSiagieMsaConfiguration:RsaLocalFolder").Value;
        var rsaRemoteFolder = Configuration.GetSection("JwtSiagieMsaConfiguration:RsaRemoteFolder").Value;
        var mode = Convert.ToInt32(Configuration.GetSection("JwtSiagieMsaConfiguration:RsaMode").Value);

        string path = $"{_env.ContentRootPath}\\{rsaLocalFolder}\\{rsaKeyName}";
        if (_env.IsProduction())
        {
            if (mode == 2) path = $"{rsaRemoteFolder}\\{rsaKeyName}";
        }

        string keyPrivate = File.ReadAllText($"{path}");

        var configuration = new JwtSiagieMsaConfiguration()
        {
            Agw = Configuration.GetSection("JwtSiagieMsaConfiguration:Agw").Value,
            Expires = Configuration.GetSection("JwtSiagieMsaConfiguration:Expires_second").Get<int>(),
            NotBefore = Configuration.GetSection("JwtSiagieMsaConfiguration:NotBefore_second").Get<float>(),
            Audience = Configuration.GetSection("JwtSiagieMsaConfiguration:Audience").Value,
            Issuer = Configuration.GetSection("JwtSiagieMsaConfiguration:Issuer").Value,
            RsaMode = Configuration.GetSection("JwtSiagieMsaConfiguration:RsaMode").Get<int>(),
            Agl = Configuration.GetSection("JwtSiagieMsaConfiguration:Agl").Value,
            Agp = Configuration.GetSection("JwtSiagieMsaConfiguration:Agp").Value,
            KeyPrivate = keyPrivate
        };

        var keySplit = configuration.KeyPrivate.Split("-----");
        configuration.KeyPrivateByte = Convert.FromBase64String(keySplit[2]);

        services.AddSingleton(configuration);
    }

    public void JwtPadronConfigurations(IServiceCollection services)
    {
        var rsaKeyName = Configuration.GetSection("JwtPadronConfiguration:rsaPrivateName").Value;
        var rsaLocalFolder = Configuration.GetSection("JwtPadronConfiguration:RsaLocalFolder").Value;
        var rsaRemoteFolder = Configuration.GetSection("JwtPadronConfiguration:RsaRemoteFolder").Value;
        var mode = Convert.ToInt32(Configuration.GetSection("JwtPadronConfiguration:RsaMode").Value);

        string path = $"{_env.ContentRootPath}\\{rsaLocalFolder}\\{rsaKeyName}";
        if (_env.IsProduction())
        {
            if (mode == 2) path = $"{rsaRemoteFolder}\\{rsaKeyName}";
        }

        string keyPrivate = File.ReadAllText($"{path}");

        var configuration = new JwtPadronConfiguration()
        {
            Agw = Configuration.GetSection("JwtPadronConfiguration:Agw").Value,
            Expires = Configuration.GetSection("JwtPadronConfiguration:Expires_second").Get<int>(),
            NotBefore = Configuration.GetSection("JwtPadronConfiguration:NotBefore_second").Get<float>(),
            Audience = Configuration.GetSection("JwtPadronConfiguration:Audience").Value,
            Issuer = Configuration.GetSection("JwtPadronConfiguration:Issuer").Value,
            RsaMode = Configuration.GetSection("JwtPadronConfiguration:RsaMode").Get<int>(),
            Agl = Configuration.GetSection("JwtPadronConfiguration:Agl").Value,
            Agp = Configuration.GetSection("JwtPadronConfiguration:Agp").Value,
            KeyPrivate = keyPrivate
        };

        var keySplit = configuration.KeyPrivate.Split("-----");
        configuration.KeyPrivateByte = Convert.FromBase64String(keySplit[2]);

        services.AddSingleton(configuration);
    }
}