using Back.Ctac.Domain.Enumerado;
using Minedu.Fw.NetConnect.ISQL.IRepository;

namespace Back.Ctac.Query.Enumerado;

public interface IQueryEnumeradoRepository :
    IQueryAsyncRepository<USP_SEL_ENUMERADO_Result, string>
{
}