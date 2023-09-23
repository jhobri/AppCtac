using MediatR;

namespace Back.Ctac.Query.Estudiante.ByIeEvaluadorMultiple;

public class EstudiantesByIeEvaluadorMultipleQuery : IRequest<IEnumerable<EstudianteEvaluacionResponse>>
{
    public EstudianteEvaluacionRequest entity;

    public EstudiantesByIeEvaluadorMultipleQuery(EstudianteEvaluacionRequest request)
    {
        entity = request;
    }
}