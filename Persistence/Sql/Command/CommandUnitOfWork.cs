
using Back.Ctac.Command;
using Back.Ctac.Command.AutorizacionEvaluacion;
using Back.Ctac.Command.ResponsableEvaluacion;

namespace Back.Ctac.Data.Command;

public class CommandUnitOfWork : ICommandUnitOfWork
{



    public ICommandResponsableEvaluacionInsRepository ResponsableEvaluacionInsRepository { get; }
    public ICommandAutorizacionEvaluacionRepository AutorizacionEvaluacionRepository { get; }

    public CommandUnitOfWork(
ICommandResponsableEvaluacionInsRepository responsableEvaluacionInsRepository
, ICommandAutorizacionEvaluacionRepository autorizacionEvaluacionRepository

    )
    {
        ResponsableEvaluacionInsRepository = responsableEvaluacionInsRepository;
        AutorizacionEvaluacionRepository = autorizacionEvaluacionRepository;
    }
}