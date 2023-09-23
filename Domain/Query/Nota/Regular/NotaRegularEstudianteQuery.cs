using Back.Ctac.Dto.Nota;
using MediatR;

namespace Back.Ctac.Query.Nota.Regular;

public class NotaRegularEstudianteQuery : IRequest<IEnumerable<NotaEstudianteResponse>>
{
    public NotaRegularEstudianteRequest entity;

    public NotaRegularEstudianteQuery(NotaRegularEstudianteRequest request)
    {
        entity = request;
    }
}