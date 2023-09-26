using AutoMapper;
using Back.Ctac.Dto.Publicidad;
using Back.Ctac.IApplication.UseCases.Publicidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Minedu.Fw.General.Response.Status;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Back.Ctac.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/negocio/v{version:apiVersion}/publicidad")]
    public class PublicidadController : ControllerBase
    {
        protected readonly IPublicidadApplication _application;
        protected readonly IMediator _mediator;
     
        public PublicidadController(IPublicidadApplication application,IMediator mediator)
        {
            _application = application;
            _mediator = mediator;
        }
        /// <remarks>
        /// <b>Parámetros</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// <b>Restricciones</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// <b>Reglas de negocio</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// </remarks>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Publicidad" }, Summary = "Obtener lista de publicidad", OperationId = "getPublicidad")]
        //[ProducesResponseType(typeof(StatusResponse<AreaLenguaResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(StatusResponse<IEnumerable<GetPublicidadResponseDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {

            var data = await _application.getPublicidad();
            if (!data.Any()) return NotFound(BuildResponse.Code40401(data));
            return Ok(BuildResponse.Code20001(data));
        }

        /// <remarks>
        /// <b>Parámetros</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// <b>Restricciones</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// <br/>
        /// <br/>
        /// <br/>
        /// <br/>
        /// <b>Reglas de negocio</b>
        /// <ul>
        /// <li>Ninguno</li>
        /// </ul>
        /// </remarks>
        [HttpGet("id")]
        [SwaggerOperation(Tags = new[] { "Publicidad" }, Summary = "Obtener lista de publicidad por id", OperationId = "getPublicidadById")]
        [ProducesResponseType(typeof(StatusResponse<GetPublicidadResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([FromQuery] GetPublicidadResponseRequest request)
        {

            var data = await _application.getPublicidadById(request);
            if (data is null) return NotFound(BuildResponse.Code40401(data));
            return Ok(BuildResponse.Code20001(data));
        }

    }
}
