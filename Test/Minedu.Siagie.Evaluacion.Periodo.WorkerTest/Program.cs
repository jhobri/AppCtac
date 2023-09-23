using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Minedu.Fw.General.Models.Configurations;
using Minedu.Siagie.Evaluacion.Periodo.WorkerTest;
using Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Extensions;
using Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Infrastructure.Modules;
using Minedu.Siagie.Rest.Service.SiagieMsa;

IHost host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        builder.RegisterModule(new MediatorModule(configuration));
    })
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration Configuration = hostContext.Configuration;
        // public void JwtSiagieMsaConfigurations(IServiceCollection services)
        IHostEnvironment _env = hostContext.HostingEnvironment;
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

        // public void JwtPadronConfigurations(IServiceCollection services)
        rsaKeyName = Configuration.GetSection("JwtPadronConfiguration:rsaPrivateName").Value;
        rsaLocalFolder = Configuration.GetSection("JwtPadronConfiguration:RsaLocalFolder").Value;
        rsaRemoteFolder = Configuration.GetSection("JwtPadronConfiguration:RsaRemoteFolder").Value;
        mode = Convert.ToInt32(Configuration.GetSection("JwtPadronConfiguration:RsaMode").Value);

        path = $"{_env.ContentRootPath}\\{rsaLocalFolder}\\{rsaKeyName}";
        if (_env.IsProduction())
        {
            if (mode == 2) path = $"{rsaRemoteFolder}\\{rsaKeyName}";
        }

        keyPrivate = File.ReadAllText($"{path}");

        var configuration2 = new JwtPadronConfiguration()
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

        keySplit = configuration2.KeyPrivate.Split("-----");
        configuration2.KeyPrivateByte = Convert.FromBase64String(keySplit[2]);

        services.AddSingleton(configuration2);

        //IConfiguration Configuration = hostContext.Configuration;
        // services.Configure<DatabaseOptions>(Configuration.GetSection("Database"));

        services.Configure<SecurityCentralConfiguration>(Configuration.GetSection("SecurityCentralConfiguration"));
        services.Configure<RequestConfiguration>(Configuration.GetSection("RequestConfiguration"));
        services.Configure<GlobalConfiguration>(Configuration.GetSection("GlobalConfiguration"));
        services.Configure<MsaAppDevModeConfiguration>(Configuration.GetSection("MsaAppDevModeConfiguration"));
      //  services.Configure<InformeProgresoConfiguration>(Configuration.GetSection("InformeProgresoConfiguration"));
        services.Configure<MigradorConfiguration>(Configuration.GetSection("MigradorConfiguration"));

        var mappingConfig = new MapperConfiguration(mc =>
        {
            //mc.AddProfile(new DatoPaqueteBoletaMap());
            //mc.AddProfile(new DatoPaqueteBoletaEbaMap());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        //MongoConfiguration.Startup();

        services.AddHostedService<Worker>();
       // services.RegisterConfigurationServices(hostContext);
        services.RegisterConfigurationLoginServices(hostContext);
        services.AddRestCustomClient<ISiagieMsaIeAdministracionApiGateway>("siagie-msa-gateway-ie-administracion");
        services.AddRestCustomClient<ISiagieMsaEvaluacionPeriodoApiGateway>("siagie-msa-gateway-evaluacion-periodo");
        // services.RegisterQueueServices(hostContext);
    })
    //.ConfigureServices(services =>
    //{
    //    services.AddHostedService<Worker>();
    //})
    .Build();

await host.RunAsync();