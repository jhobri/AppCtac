using AutoMapper;
using Back.Ctac.Domain.Enumerado;
using Back.Ctac.Query;
using MediatR;

namespace Back.Ctac.Query.Enumerado;

public class EnumeradoHandler : IRequestHandler<EnumeradoQuery, IEnumerable<EnumeradoResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;

    public EnumeradoHandler(IQueryUnitOfWork uow, IMapper mapper, IMediator mediator)
    {
        _uow = uow;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<EnumeradoResponse>> Handle(EnumeradoQuery request, CancellationToken cancellationToken)
    {


        var result = await _uow.EnumeradoRepository.GetAsync(request.entity.Enumerado);
        return _mapper.Map<IEnumerable<USP_SEL_ENUMERADO_Result>, IEnumerable<EnumeradoResponse>>(result);
    }
}