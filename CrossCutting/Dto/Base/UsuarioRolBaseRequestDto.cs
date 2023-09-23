using Minedu.Fw.General.Filters.Swagger;

namespace Back.Ctac.Dto.Base
{
    public class UsuarioRolBaseRequestDto : UsuarioBaseRequestDto
    {
        [SwaggerJsonIgnore]
        public string RolId { get; set; }
    }
}