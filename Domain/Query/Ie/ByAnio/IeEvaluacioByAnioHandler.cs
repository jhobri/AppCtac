using AutoMapper;
using Back.Ctac.Domain.Ie;
using MediatR;

namespace Back.Ctac.Query.Ie.ByAnio;
public class IeEvaluacioByAnioHandler : IRequestHandler<IeEvaluacioByAnioQuery, IeEvaluacionResponse>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public IeEvaluacioByAnioHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IeEvaluacionResponse> Handle(IeEvaluacioByAnioQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.IeEvaluacionRepository.GetByAnioAsync(request.entity);
        return _mapper.Map<USP_SEL_IE_EVALUACION_BY_ANIO_Result, IeEvaluacionResponse>(result);
    }
}