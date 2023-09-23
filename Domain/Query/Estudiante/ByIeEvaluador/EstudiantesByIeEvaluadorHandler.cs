using AutoMapper;
using Back.Ctac.Domain.Estudiante;
using MediatR;


namespace Back.Ctac.Query.Estudiante.ByIeEvaluador;
public class EstudiantesByIeEvaluadorHandler : IRequestHandler<EstudiantesByIeEvaluadorQuery, IEnumerable<EstudianteEvaluacionByIeResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public EstudiantesByIeEvaluadorHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EstudianteEvaluacionByIeResponse>> Handle(EstudiantesByIeEvaluadorQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.EstudianteRepository.GetByIeEvaluadorAsync(request.entity);
        return _mapper.Map<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_Result>, IEnumerable<EstudianteEvaluacionByIeResponse>>(result).ToList();
    }
}