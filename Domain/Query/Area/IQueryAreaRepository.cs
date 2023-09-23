using Back.Ctac.Domain.Area;

namespace Back.Ctac.Query.Area;

public interface IQueryAreaRepository
{

    Task<IEnumerable<USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR_Result>> GetAreasDesaprobadosEstudiantesByIeEvaluadorAsync(AreasDesaprobadosEstudiantesRequest entity);
}