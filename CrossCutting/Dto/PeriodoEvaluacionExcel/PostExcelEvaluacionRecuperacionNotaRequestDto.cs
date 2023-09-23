
using Back.Ctac.Dto.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel
{
    public class PostExcelEvaluacionRecuperacionNotaRequestDto : InstitucionEducativaAnioBaseRequestDto
    {

        [DisplayName("El Grado")]
        public string GradoId { get; set; }

        [DisplayName("El rol")]
        public string RolId { get; set; }

        [DisplayName("El archivo")]
        public IFormFile File { get; set; }

    }


}
