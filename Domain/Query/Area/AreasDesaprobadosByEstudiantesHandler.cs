using AutoMapper;
using Back.Ctac.Domain.Area;
using MediatR;

namespace Back.Ctac.Query.Area;
public class AreasDesaprobadosByEstudiantesHandler : IRequestHandler<AreasDesaprobadosByEstudiantesQuery, IEnumerable<AreasDesaprobadosEstudiantesResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public AreasDesaprobadosByEstudiantesHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AreasDesaprobadosEstudiantesResponse>> Handle(AreasDesaprobadosByEstudiantesQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.AreaRepository.GetAreasDesaprobadosEstudiantesByIeEvaluadorAsync(request.entity);
        return _mapper.Map<IEnumerable<USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR_Result>, IEnumerable<AreasDesaprobadosEstudiantesResponse>>(result).ToList();
    }
}