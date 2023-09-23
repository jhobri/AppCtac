using AutoMapper;
using Back.Ctac.Domain;
using Back.Ctac.Dto;
using MediatR;


namespace Back.Ctac.Query
{
    public class ResponsableEvaluacionHandler : IRequestHandler<ResponsableEvaluacionQuery, IEnumerable<GetAreaResponsableLstResponse>>
    {
        private readonly IQueryUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public ResponsableEvaluacionHandler(IQueryUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GetAreaResponsableLstResponse>> Handle(ResponsableEvaluacionQuery request, CancellationToken cancellationToken)
        {
            var result = await _uow.ResponsableEvaluacionRepository.GetAsync(new USP_SEL_GRADO_AREA_RESPONSABLE_Request()
            {
                COD_MOD = request.entity.CodigoModular,
                ANEXO = request.entity.Anexo,
                ID_ANIO = (short)request.entity.Anio,
                ID_NIVEL = request.entity.Nivel,
                ID_GRADO = request.entity.GradoId
            });
            return _mapper.Map<IEnumerable<USP_SEL_GRADO_AREA_RESPONSABLE_Result>, IEnumerable<GetAreaResponsableLstResponse>>(result);
        }
    }
}
