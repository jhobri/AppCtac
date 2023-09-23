
using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Query.Estudiante.ByIeEvaluador;
using Back.Ctac.Query.Estudiante.ByIeEvaluadorMultiple;

namespace Back.Ctac.Query.Estudiante;

public interface IQueryEstudianteRepository
{

    Task<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_Result>> GetByIeEvaluadorAsync(EstudianteEvaluacionByIeRequest entity);
    Task<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE_Result>> GetByIeEvaluadorMultipleAsync(EstudianteEvaluacionRequest entity);
    Task<USP_SEL_ESTUDIANTES_SECCION_BY_ID_Result> GetByIdSeccionEstudianteAsync(int entity);
}