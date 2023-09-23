using Back.Ctac.Api.Configurations;
using Back.Ctac.Api.Filters;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Minedu.Fw.General.Filters.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Back.Ctac.Api.Extensions;

public static class CustomExtensionsSwagger
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerVersionServices>();

        services.AddSwaggerGen(c =>
        {
            c.OperationFilter<SwaggerDefaultValues>();
            c.SwaggerDoc("v1.0", new OpenApiInfo
            {
                Title = "Microservice API",
                Version = "v1",
                Description = "Microservice Architecture",
                Contact = new OpenApiContact
                {
                    Name = "Microservice",
                    Email = "empresa@gmail.com.pe"
                },
                License = new OpenApiLicense
                {
                    Name = "Derechos Reservados"
                },
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
            c.SchemaFilter<SwaggerBodyJsonIgnore>();
            c.OperationFilter<SwaggerQueryJsonIgnore>();
            c.OperationFilter<SwaggerAddRequiredHeaderParameter>();
            c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
            c.DescribeAllParametersInCamelCase();
        });

        services.AddFluentValidationRulesToSwagger();

        return services;
    }
}