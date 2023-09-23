using AutoMapper;
using Back.Ctac.Domain.Grado;
using MediatR;

namespace Back.Ctac.Query.Grado.ByIe;
public class GradosHandler : IRequestHandler<GradosQuery, IEnumerable<GradoResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public GradosHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GradoResponse>> Handle(GradosQuery request, CancellationToken cancellationToken)
    {
        var result = await _uow.GradoRepository.GetByIeAsync(request.entity);
        return _mapper.Map<IEnumerable<USP_SEL_GRADO_BY_IE_Result>, IEnumerable<GradoResponse>>(result).ToList();
    }
}