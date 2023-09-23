using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Back.Ctac.Api.Configurations;

public class ConfigureSwaggerVersionServices : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;
    public IConfiguration Configuration { get; }

    public ConfigureSwaggerVersionServices(IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        this.provider = provider;
        Configuration = configuration;
    }

    public void Configure(SwaggerGenOptions options)
    {
        string urlDocumentoValidacion = Configuration["UrlDocumentoValidacion"];
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, urlDocumentoValidacion));
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, string url)
    {
        var info = new OpenApiInfo()
        {
            Title = "APP > Microservice > API",
            Version = description.ApiVersion.ToString(),
            Description = "Catalogo de recursos disponibles",
            Contact = new OpenApiContact() { Name = "OTIC @ EMPRESA", Email = "desarrollador@gmail.comp.pe" },
            License = new OpenApiLicense() { Name = "Documentación de validaciones", Url = new Uri(url) },
        };

        if (description.IsDeprecated)
        {
            info.Description += "Esta API ha quedado obsoleta.";
        }

        return info;
    }
}