using MediatR;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Command.AutorizacionEvaluacion.Ins;

public class AutorizacionEvaluacionInsCommand : IRequest<StatusResponse<int>>
{
    public AutorizacionEvaluacionInsRequest entity;

    public AutorizacionEvaluacionInsCommand(AutorizacionEvaluacionInsRequest entity)
    {
        this.entity = entity;
    }
}
