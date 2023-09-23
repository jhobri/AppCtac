using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Domain.General;

namespace Back.Ctac.Command.AutorizacionEvaluacion;

public interface ICommandAutorizacionEvaluacionRepository
{
    public Task<GenericCommandResult<int>> UpdAutorizacionAsync(USP_UPD_AUTORIZACION_EVALUACION_EXTERNA_Request entity);
}
