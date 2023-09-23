using Back.Ctac.Dto.Base;
using System.ComponentModel;

namespace Back.Ctac.Dto
{
    public class PostResponsableRecuperacionRequest : InstitucionEducativaAnioBaseRequestDto
    {
        public string Nivel { get; set; }
        public string GradoId { get; set; }
        public IEnumerable<AreaResponsableRequest> Areas { get; set; }
    }
    public class AreaResponsableRequest
    {
        public string IdArea { get; set; }
        public int IdPersona { get; set; }
    }
}
