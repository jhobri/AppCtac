using Back.Ctac.Domain;
using Minedu.Fw.NetConnect.ISQL.IRepository;


namespace Back.Ctac.Query
{
    public interface IQueryResponsableEvaluacionRepository :
        IQueryAsyncRepository<USP_SEL_GRADO_AREA_RESPONSABLE_Result, USP_SEL_GRADO_AREA_RESPONSABLE_Request>
    {
    }
}
