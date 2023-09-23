using Back.Ctac.Domain.Ie;
using Back.Ctac.Query.Ie.ByAnio;

namespace Back.Ctac.Query.Ie;

public interface IQueryIeEvaluacionRepository
{


    Task<USP_SEL_IE_EVALUACION_BY_ANIO_Result> GetByAnioAsync(IeEvaluacionRequest entity);
}