using AutoMapper;
using Back.Ctac.Domain.Estudiante;
using MediatR;


namespace Back.Ctac.Query.Estudiante.ByIeEvaluadorMultiple;
public class EstudiantesByIeEvaluadorMultipleHandler : IRequestHandler<EstudiantesByIeEvaluadorMultipleQuery, IEnumerable<EstudianteEvaluacionResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public EstudiantesByIeEvaluadorMultipleHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EstudianteEvaluacionResponse>> Handle(EstudiantesByIeEvaluadorMultipleQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.EstudianteRepository.GetByIeEvaluadorMultipleAsync(request.entity);
        return _mapper.Map<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE_Result>, IEnumerable<EstudianteEvaluacionResponse>>(result).ToList();
    }
}