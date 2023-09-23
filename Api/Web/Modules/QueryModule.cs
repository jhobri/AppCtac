using Autofac;
using Back.Ctac.Data;
using Back.Ctac.Data.Query;
using Back.Ctac.Query;
using Back.Ctac.Query.Area;
using Back.Ctac.Query.Enumerado;
using Back.Ctac.Query.Estudiante;
using Back.Ctac.Query.Grado;
using Back.Ctac.Query.Ie;
using Back.Ctac.Query.Nota;

namespace Back.Ctac.Api.Modules;

public class QueryModule : Module
{
    public string QueriesConnectionString { get; }

    public QueryModule(string qconstr)
    {
        QueriesConnectionString = qconstr;
    }

    protected override void Load(ContainerBuilder builder)
    {




        builder.RegisterType<QueryGradoRepository>().As<IQueryGradoRepository>().WithParameter("connectionString", QueriesConnectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<QueryResponsableEvaluacionRepository>().As<IQueryResponsableEvaluacionRepository>().WithParameter("connectionString", QueriesConnectionString)
               .InstancePerLifetimeScope();


        builder.RegisterType<QueryEstudianteRepository>().As<IQueryEstudianteRepository>().WithParameter("connectionString", QueriesConnectionString)
        .InstancePerLifetimeScope();

        builder.RegisterType<QueryAreaRepository>().As<IQueryAreaRepository>().WithParameter("connectionString", QueriesConnectionString)
        .InstancePerLifetimeScope();
        builder.RegisterType<QueryIeEvaluacionRepository>().As<IQueryIeEvaluacionRepository>().WithParameter("connectionString", QueriesConnectionString)
      .InstancePerLifetimeScope();

        builder.RegisterType<QueryEnumeradoRepository>().As<IQueryEnumeradoRepository>().WithParameter("connectionString", QueriesConnectionString)
   .InstancePerLifetimeScope();

        builder.RegisterType<QueryNotaEstudianteRepository>().As<IQueryNotaEstudianteRepository>().WithParameter("connectionString", QueriesConnectionString)
   .InstancePerLifetimeScope();


        builder.RegisterType<QueryUnitOfWork>().As<IQueryUnitOfWork>()
            .InstancePerLifetimeScope();
    }
}