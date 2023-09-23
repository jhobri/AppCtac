using MediatR;

namespace Back.Ctac.Query.Estudiante.ByIdSeccionEstudiante;

public class EstudianteSeccionByIdQuery : IRequest<EstudianteSeccionResponse>
{
    public int entity;

    public EstudianteSeccionByIdQuery(int request)
    {
        entity = request;
    }
}