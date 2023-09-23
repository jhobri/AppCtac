using MediatR;

namespace Back.Ctac.Query.Ie.ByAnio;

public class IeEvaluacioByAnioQuery : IRequest<IeEvaluacionResponse>
{
    public IeEvaluacionRequest entity;

    public IeEvaluacioByAnioQuery(IeEvaluacionRequest request)
    {
        entity = request;
    }
}