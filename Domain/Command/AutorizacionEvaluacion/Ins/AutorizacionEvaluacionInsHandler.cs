using AutoMapper;
using Back.Ctac.Command.Messages;
using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Query.Estudiante.ByIdSeccionEstudiante;
using Back.Ctac.Query.Ie.ByAnio;
using MediatR;
using Minedu.Fw.General.Response.Status;


namespace Back.Ctac.Command.AutorizacionEvaluacion.Ins;

public class AutorizacionEvaluacionInsHandler : IRequestHandler<AutorizacionEvaluacionInsCommand, StatusResponse<int>>
{
    private readonly ICommandUnitOfWork _uow;
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;

    public AutorizacionEvaluacionInsHandler(ICommandUnitOfWork uow, IMapper mapper, IMediator mediator)
    {
        _uow = uow;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<StatusResponse<int>> Handle(AutorizacionEvaluacionInsCommand request, CancellationToken cancellationToken)
    {
        var cltToken = new CancellationToken();
        var response = new StatusResponse<int>();



        var data = await _mediator.Send(new EstudianteSeccionByIdQuery(request.entity.EstudianteSeccionId), cltToken);

        var ieEvaluacion = await _mediator.Send(new IeEvaluacioByAnioQuery(new IeEvaluacionRequest { CodigoModular = request.entity.CodigoModular, Anexo = request.entity.Anexo, Anio = request.entity.Anio }), cltToken);





        var trx = await _uow.AutorizacionEvaluacionRepository.UpdAutorizacionAsync(
            new USP_UPD_AUTORIZACION_EVALUACION_EXTERNA_Request()
            {
                ID_ESTUDIANTE_SECCION = request.entity.EstudianteSeccionId,
                COD_MOD_EVALUACION = request.entity.CodigoModular,
                NRO_RESOLUCION = request.entity.Resolucion,
                FECHA_RESOLUCION = request.entity.Fecha,
                USUARIO_REGISTRA = request.entity.Usuario,
            });

        response.Data = trx.Result;
        response.Success = trx.Result > 0;
        response.Message = trx.Result > 0 ? null : CommandGlobalMessages.NINGUN_REGISTRO_ACTUALIZADO;



        return response;
    }
}