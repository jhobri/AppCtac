using Back.Ctac.Query.Area;
using Back.Ctac.Query.Enumerado;
using Back.Ctac.Query.Estudiante;
using Back.Ctac.Query.Grado;
using Back.Ctac.Query.Ie;
using Back.Ctac.Query.Nota;

namespace Back.Ctac.Query;

public interface IQueryUnitOfWork
{

    IQueryEstudianteRepository EstudianteRepository { get; }
    IQueryGradoRepository GradoRepository { get; }
    IQueryAreaRepository AreaRepository { get; }
    IQueryEnumeradoRepository EnumeradoRepository { get; }
    IQueryResponsableEvaluacionRepository ResponsableEvaluacionRepository { get; }
    IQueryIeEvaluacionRepository IeEvaluacionRepository { get; }
    IQueryNotaEstudianteRepository NotaEstudianteRepository { get; }


}