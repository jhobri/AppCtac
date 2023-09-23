using Microsoft.AspNetCore.Mvc;

namespace Back.Ctac.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/evaluacion-periodo/v{version:apiVersion}/error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("notfound")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<string> Get()
        {
            return NotFound("SIAGIE MSA ::: MINEDU");
        }
    }
}