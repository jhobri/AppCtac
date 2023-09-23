using AutoMapper;
using Back.Ctac.Command.ResponsableEvaluacion;
using Back.Ctac.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Minedu.Fw.General.Response.Status;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Back.Ctac.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/evaluacion-periodo/v{version:apiVersion}/responsables-evaluaciones")]
public class ResponsableEvaluacionController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;

    public ResponsableEvaluacionController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerOperation(Tags = new[] { "Recuperacion - responsables de evaluación" }, Summary = "Grabar responsables de evaluación",
        OperationId = "PostResponsableRecuperacionRequest")]
    [ProducesResponseType(typeof(StatusResponse<bool>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post([FromBody] PostResponsableRecuperacionRequest request)
    {
        var cltToken = new CancellationToken();
        var data = await _mediator.Send(new ResponsableEvaluacionInsCommand(
                                        new ResponsableEvaluacionInsRequest()
                                        {
                                            CodigoModular = request.CodigoModular,
                                            Anexo = request.Anexo,
                                            Anio = request.Anio!.Value,
                                            Nivel = request.Nivel,
                                            Grado = request.GradoId,
                                            RolId = request.RolId,
                                            Usuario = request.Usuario,
                                            Areas = _mapper.Map<IEnumerable<AreaResponsableRequest>, IEnumerable<AreaResponsableInsRequest>>(request.Areas)
                                        }), cltToken);

        if (data.Validations.Any())
        {
            var response = (StatusResponse<string>)BuildResponse.Code40001(data.Validations);
            return BadRequest(response);
        }

        if (data.Data <= 0) return BadRequest(BuildResponse.Code50001());
        return Ok(BuildResponse.Code20001(data.Data));
    }
}
