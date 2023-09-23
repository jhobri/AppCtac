using Autofac;
using Back.Ctac.Command;
using Back.Ctac.Command.AutorizacionEvaluacion;
using Back.Ctac.Command.ResponsableEvaluacion;
using Back.Ctac.Data.Command;


namespace Back.Ctac.Api.Modules;

public class CommandModule : Module
{
    public string QueriesConnectionString { get; }

    public CommandModule(string qconstr)
    {
        QueriesConnectionString = qconstr;
    }

    protected override void Load(ContainerBuilder builder)
    {

        //REGISTRAR TODO LOS COMMAND

        builder.RegisterType<CommandAutorizacionEvaluacionRepository>().As<ICommandAutorizacionEvaluacionRepository>().WithParameter("connectionString", QueriesConnectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<CommandResponsableEvaluacionRepository>().As<ICommandResponsableEvaluacionInsRepository>().WithParameter("connectionString", QueriesConnectionString)
           .InstancePerLifetimeScope();


        builder.RegisterType<CommandUnitOfWork>().As<ICommandUnitOfWork>()
            .InstancePerLifetimeScope();
    }
}