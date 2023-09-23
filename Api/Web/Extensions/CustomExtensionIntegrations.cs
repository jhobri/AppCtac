using Back.Ctac.Application.UseCases;
using Back.Ctac.IApplication.UseCases;
using Minedu.Fw.Security.Jwt.Models;

//using Minedu.Siagie.Soa.Service.Padron;

namespace Back.Ctac.Api.Extensions;

public static class CustomExtensionIntegrations
{
    public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, SoaEndpointConfiguration wcf)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();        
       // services.AddScoped<IPadronService>(provider => new PadronService(wcf.EscaleService));


        //INYECTAR APLICACIONES
        
        services.AddTransient<IFrutaApplication, FrutaApplication>();
        




        return services;
    }
}