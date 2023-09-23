using AutoMapper;
using Back.Ctac.Domain.Estudiante;
using MediatR;

namespace Back.Ctac.Query.Estudiante.ByIdSeccionEstudiante;
public class EstudianteSeccionByIdHandler : IRequestHandler<EstudianteSeccionByIdQuery, EstudianteSeccionResponse>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public EstudianteSeccionByIdHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<EstudianteSeccionResponse> Handle(EstudianteSeccionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.EstudianteRepository.GetByIdSeccionEstudianteAsync(request.entity);
        return _mapper.Map<USP_SEL_ESTUDIANTES_SECCION_BY_ID_Result, EstudianteSeccionResponse>(result);
    }
}