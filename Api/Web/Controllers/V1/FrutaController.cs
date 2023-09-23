using Back.Ctac.Dto.Fruta;
using Back.Ctac.IApplication.UseCases;
using Microsoft.AspNetCore.Mvc;
using Minedu.Fw.General.Response.Status;

using Swashbuckle.AspNetCore.Annotations;

namespace Back.Ctac.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/fruta/v{version:apiVersion}/listas")]
public class FrutaController : ControllerBase
{
    private readonly IFrutaApplication _application;

    public FrutaController(IFrutaApplication application)
    {
        _application = application;
    }

    ///	<remarks>
    ///	Obtener lista de responsables de recuperación
    ///	<br/>
    ///	<br/>
    ///	### Parámetros
    ///	<table border="1">
    ///		<tr>
    ///			<td><b>Parámetro</b></td>
    ///			<td><b>Valor(es)</b></td>
    ///			<td><b>Descripción</b></td>
    ///		</tr>
    ///		<tr>
    ///			<td>CodigoModular</td>
    ///         <td>Caracteres numéricos</td>
    ///         <td>Código modular de la institución educativa</td>
    ///		</tr>
    ///		<tr>
    ///			<td>Anexo</td>
    ///         <td>Caracter numérico</td>
    ///         <td>Anexo de la institución educativa</td>
    ///		</tr>
    ///		<tr>
    ///			<td>Anio</td>
    ///         <td>Número entero positivo</td>
    ///         <td>Año académico habilitado para la institución educativa</td>
    ///		</tr>       
    ///	</table>
    ///	<br/>
    ///	<br/>
    ///	<h3> Restricciones </h3>
    ///	<ul>
    /// <li><b>Anio</b>: El año académico debe ser mayor o igual al año 2022 y menor o igual al año actual.</li>
    /// <li><b>CodigoModular</b>: El código modular debe tener 7 dígitos.</li>
    /// <li><b>Anexo</b>: El anexo debe tener 1 dígito.</li>
    ///	</ul>
    ///	<br/>
    ///	<br/>
    ///	<h3> Reglas de negocio </h3>
    ///	<ul>
    ///	<li>Disponible únicamente para modalidad EBR/EBE - "La institución educativa no es válida, pertenece a la modalidad Educación Básica Alternativa"</li>
    ///	</ul>
    ///	</remarks>
    //[FromQuery] GetFrutaLstRequest request
    [HttpGet]
    [SwaggerOperation(Tags = new[] { "Fruta - Lista de frutas" }, Summary = "Obtener lista de frutas",
    OperationId = "GetFrutaLstRequest")]
    public async Task<IActionResult> Get()
    {
        var data = await _application.GetFrutaLst();
        if (!data.Any()) return NotFound(BuildResponse.Code40401(data));
        return Ok(BuildResponse.Code20001(data));


    }
}
