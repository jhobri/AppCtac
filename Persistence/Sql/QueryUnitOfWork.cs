using Back.Ctac.Query;
using Back.Ctac.Query.Area;
using Back.Ctac.Query.Enumerado;
using Back.Ctac.Query.Estudiante;
using Back.Ctac.Query.Grado;
using Back.Ctac.Query.Ie;
using Back.Ctac.Query.Nota;

namespace Back.Ctac.Data;

public class QueryUnitOfWork : IQueryUnitOfWork
{
    public QueryUnitOfWork(



    IQueryGradoRepository gradoRepository,
     IQueryResponsableEvaluacionRepository responsableEvaluacionRepository,
     IQueryEstudianteRepository estudianteRepository,
     IQueryAreaRepository areaRepository,
     IQueryIeEvaluacionRepository ieEvaluacionRepository,
     IQueryEnumeradoRepository enumeradoRepository,
     IQueryNotaEstudianteRepository notaEstudianteRepository)
    {
        GradoRepository = gradoRepository;
        ResponsableEvaluacionRepository = responsableEvaluacionRepository;
        EstudianteRepository = estudianteRepository;
        AreaRepository = areaRepository;
        IeEvaluacionRepository = ieEvaluacionRepository;
        EnumeradoRepository = enumeradoRepository;
        NotaEstudianteRepository = notaEstudianteRepository;
    }

    public IQueryEstudianteRepository EstudianteRepository { get; }
    public IQueryGradoRepository GradoRepository { get; }
    public IQueryResponsableEvaluacionRepository ResponsableEvaluacionRepository { get; }

    public IQueryIeEvaluacionRepository IeEvaluacionRepository { get; }
    public IQueryAreaRepository AreaRepository { get; }

    public IQueryEnumeradoRepository EnumeradoRepository { get; }

    public IQueryNotaEstudianteRepository NotaEstudianteRepository { get; }
}