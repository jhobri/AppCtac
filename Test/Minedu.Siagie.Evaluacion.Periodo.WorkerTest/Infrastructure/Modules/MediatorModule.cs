using Autofac;
using MediatR;
using Minedu.Siagie.Evaluacion.Periodo.Query.EvaluacionPeriodo.Excel;
using System.Reflection;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Infrastructure.Modules
{
    public class MediatorModule : Autofac.Module
    {
        public static IConfiguration _configuration;

        public MediatorModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = _configuration.GetSection("ConnectionStrings:SiagieCommands").Value;
            string SoaconnectionString = _configuration.GetSection("ConnectionStrings:SoaCommands").Value;

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(EvaluacionPeriodoExcelQuery).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DemoInsCommand).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterType<QueryDemoRepository>().As<IQueryDemoRepository>().WithParameter("connectionString", connectionString)
            //   .InstancePerLifetimeScope();

            //builder.RegisterType<CommandDemoRepository>().As<ICommandDemoRepository>().WithParameter("connectionString", connectionString)
            //   .InstancePerLifetimeScope();

            //builder.RegisterType<MongoContext>().As<IMongoContext>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<QueryUnitOfWork>().As<IQueryUnitOfWork>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<CommandUnitOfWork>().As<ICommandUnitOfWork>()
            //    .InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}