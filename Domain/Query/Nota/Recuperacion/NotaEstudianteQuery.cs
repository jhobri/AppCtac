using Back.Ctac.Dto.Nota;
using MediatR;

namespace Back.Ctac.Query.Nota.Recuperacion;

public class NotaEstudianteQuery : IRequest<IEnumerable<NotaEstudianteResponse>>
{
    public NotaEstudianteRequest entity;

    public NotaEstudianteQuery(NotaEstudianteRequest request)
    {
        entity = request;
    }
}