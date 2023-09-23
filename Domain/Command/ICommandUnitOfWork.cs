using Back.Ctac.Command.AutorizacionEvaluacion;
using Back.Ctac.Command.ResponsableEvaluacion;

namespace Back.Ctac.Command;

public interface ICommandUnitOfWork
{

    ICommandAutorizacionEvaluacionRepository AutorizacionEvaluacionRepository { get; }
    ICommandResponsableEvaluacionInsRepository ResponsableEvaluacionInsRepository { get; }
}