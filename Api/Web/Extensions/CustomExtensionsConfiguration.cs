using Back.Ctac.Rest.Service.Configuration;
using Minedu.Fw.General.Models.Configurations;

namespace Back.Ctac.Api.Extensions;

public static class CustomExtensionsConfiguration
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var servicesUrl = configuration.GetSection("ServiceRestUrl");
        services.Configure<ServiceRestUrl>(servicesUrl);

        return services;
    }

    public static IServiceCollection AddJwtSiagieMsaConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var servicesUrl = configuration.GetSection("JwtSiagieMsaConfiguration");
        services.Configure<JwtSiagieMsaConfiguration>(servicesUrl);

        return services;
    }

    public static IServiceCollection AddJwtPadronConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var servicesUrl = configuration.GetSection("JwtPadronConfiguration");
        services.Configure<JwtPadronConfiguration>(servicesUrl);

        return services;
    }
}