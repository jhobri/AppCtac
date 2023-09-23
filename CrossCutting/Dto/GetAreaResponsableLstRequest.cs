using Back.Ctac.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Dto
{
    public class GetAreaResponsableLstRequest : InstitucionEducativaAnioBaseRequestDto
    {

        [DisplayName("El Nivel Académico")]
        public string Nivel { get; set; }

        [DisplayName("El Grado Académico")]
        public string GradoId { get; set; }
    }
}
