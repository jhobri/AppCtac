using Back.Ctac.Api;
using FluentValidation.AspNetCore;

namespace Back.Ctac.Api.Extensions
{
    public static class CustomExtensionFluentValidation
    {
        public static IServiceCollection AddFluent(this IServiceCollection services)
        {
            services.AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                configuration.DisableDataAnnotationsValidation = true;
                configuration.ImplicitlyValidateChildProperties = true;
            });
            return services;
        }
    }
}