using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Dto.Base
{
    public class InstitucionEducativaGradoNullBaseRequestDto<T> : InstitucionEducativaAnioBaseRequestDto
    {
        public T? GradoId { get; set; }
    }
}
