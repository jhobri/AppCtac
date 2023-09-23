using Autofac;
using Back.Ctac.Api.Behaviors;
using Back.Ctac.Command.AutorizacionEvaluacion.Ins;
using Back.Ctac.Query.Estudiante.ByIdSeccionEstudiante;
using MediatR;
using System.Reflection;

namespace Back.Ctac.Api.Modules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();


        builder.RegisterAssemblyTypes(typeof(EstudianteSeccionByIdQuery).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));


        /* HABILITAR PARA LOS INSERT*/
        builder.RegisterAssemblyTypes(typeof(AutorizacionEvaluacionInsHandler).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.Register<ServiceFactory>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
        });

        builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));

    }
}