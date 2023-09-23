using Back.Ctac.Domain.General;
using Back.Ctac.Domain.ResponsableEvaluacion;
using Minedu.Fw.NetConnect.ISQL.IRepository;

namespace Back.Ctac.Command.ResponsableEvaluacion
{
    public interface ICommandResponsableEvaluacionInsRepository : IInsertAsyncRepository<GenericCommandResult<int>, USP_INS_GRADO_AREA_RESPONSABLE_Request>
    {
    }
}
