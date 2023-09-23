using MediatR;

namespace Back.Ctac.Query.Grado.ByIe;

public class GradosQuery : IRequest<IEnumerable<GradoResponse>>
{
    public GradoRequest entity;

    public GradosQuery(GradoRequest request)
    {
        entity = request;
    }
}