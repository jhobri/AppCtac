using MediatR;


namespace Back.Ctac.Query.Estudiante.ByIeEvaluador;

public class EstudiantesByIeEvaluadorQuery : IRequest<IEnumerable<EstudianteEvaluacionByIeResponse>>
{
    public EstudianteEvaluacionByIeRequest entity;

    public EstudiantesByIeEvaluadorQuery(EstudianteEvaluacionByIeRequest request)
    {
        entity = request;
    }
}