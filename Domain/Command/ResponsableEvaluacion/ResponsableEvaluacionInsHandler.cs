using AutoMapper;

using MediatR;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Command.ResponsableEvaluacion;

public class ResponsableEvaluacionInsHandler : IRequestHandler<ResponsableEvaluacionInsCommand, StatusResponse<int>>
{
    private readonly ICommandUnitOfWork _uow;
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;


    public ResponsableEvaluacionInsHandler(ICommandUnitOfWork uow, IMapper mapper, IMediator mediator)
    {
        _uow = uow;
        _mapper = mapper;
        _mediator = mediator;
      
    }

    public async Task<StatusResponse<int>> Handle(ResponsableEvaluacionInsCommand request, CancellationToken cancellationToken)
    {
        var response = new StatusResponse<int>();
     /*
        var providerGeneral = new GeneralProvider(_mediator, _appAdministracion, _appEvaluacionGeneral);
        var ie = await providerGeneral.GetIe(request.entity.CodigoModular, request.entity.Anexo, request.entity.Anio);

        #region VALIDAR-ACTAS
        var actas = await providerGeneral.GetActas(request.entity.CodigoModular, request.entity.Anexo, request.entity.Anio, ie.ModalidadId, "04", request.entity.Grado, null);
        if (actas is not null)
        {
            if (actas.Any(x => x.EstadoFormatoSeccionId == 0 || x.EstadoFormatoSeccionId == 1))
            {
                CustomException.Excepcion("No se puede realizar el grabado ya que el grado cuenta con acta de recuperación generada y/o aprobada.", string.Empty);
            }
        }
        #endregion

        var _request = _mapper.Map<ResponsableEvaluacionInsRequest, USP_INS_GRADO_AREA_RESPONSABLE_Request>(request.entity);
        var _result = await _uow.ResponsableEvaluacionInsRepository.InsertAsync(_request);

        response.Success = _result.Result > 0;
        response.Data = _result.Result;
        response.Message = _result.Result > 0 ? "Datos grabados correctamente " : "No se pudo grabar los datos";
    */
        return response;
    }
}
