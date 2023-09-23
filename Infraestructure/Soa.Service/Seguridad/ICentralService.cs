//using CentralWrapper = Med.BsnEntitySeguridad;

using Med.BsnEntitySeguridad;

namespace Minedu.Siagie.Soa.Service.Seguridad;

public interface ICentralService
{
    BEUsuarioPermiso GetUsuarioPermiso(string sLogin, string sSistema);
}

//BEPadronWCF oBEPadron = new EscaleServicesClient().ExecuteProxy(x => x.PadronObtenerSIAGIE2(ViewModel.IdInstitucion, ViewModel.Anexo));