using Med.BsnEntitySeguridad;
using Minedu.Fw.Soa;

namespace Minedu.Siagie.Soa.Service.Seguridad;

public class CentralService : ICentralService
{
    private readonly IWcf<ISeguridadServices> clientProxy;

    public CentralService(string endpointUrl)
    {
        clientProxy = new Wcf<ISeguridadServicesChannel>(endpointUrl);
    }

    public CentralService(IWcf<ISeguridadServicesChannel> proxy)
    {
        clientProxy = proxy;
    }

    public BEUsuarioPermiso GetUsuarioPermiso(string sLogin, string sSistema)
    {
        try
        {
            var result = clientProxy.Execute(client => client.UsuarioPermisotraerporDefecto(sLogin, sSistema));
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}