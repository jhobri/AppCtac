using MediatR;


namespace Back.Ctac.Query.Area;

public class AreasDesaprobadosByEstudiantesQuery : IRequest<IEnumerable<AreasDesaprobadosEstudiantesResponse>>
{
    public AreasDesaprobadosEstudiantesRequest entity;

    public AreasDesaprobadosByEstudiantesQuery(AreasDesaprobadosEstudiantesRequest request)
    {
        entity = request;
    }
}