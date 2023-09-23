using System.ComponentModel;

namespace Back.Ctac.Dto.Base
{
    public class InstitucionEducativaAnioBaseRequestDto : InstitucionEducativaBaseRequestDto
    {
        [DisplayName("El año académico")]
        public short? Anio { get; set; }
    }
}