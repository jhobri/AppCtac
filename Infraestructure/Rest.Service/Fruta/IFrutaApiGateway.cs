using Back.Ctac.Rest.Service.Proxy.Model.Fruta;
using Minedu.Fw.Api.Rest;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Rest.Service.Fruta
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IFrutaApiGateway
    {
        [AllowAnyStatusCode]
        [Post("api/proceso/v1/procesos")]
        Task<StatusResponse<dynamic>> RegistrarProceso([Body] PostProcesoRequest param);

        /*
        [AllowAnyStatusCode]
        [Get("api/proceso/v1/procesos")]
        Task<StatusResponse<IEnumerable<GetPeriodoEvaluacionTipoRestResponse>>> GetProcesoById([Query] string Id );
        */
        /*
        [AllowAnyStatusCode]
        [Get("api/listar_frutas")]
        Task<StatusResponse<dynamic>> GetFrutas([Query] GetValidacionProcesoRequest param);
        */
        [AllowAnyStatusCode]
        [Get("api/listar_frutas")]
        Task<StatusResponse<dynamic>> GetFrutas();
    }
}