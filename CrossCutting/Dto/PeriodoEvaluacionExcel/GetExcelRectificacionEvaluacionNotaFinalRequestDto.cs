using Back.Ctac.Dto.Base;
using System.ComponentModel;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel
{
    public class GetExcelRectificacionEvaluacionNotaFinalRequestDto : InstitucionEducativaAnioBaseRequestDto
    {


        [DisplayName("El Grado")]
        public string GradoId { get; set; }

        [DisplayName("La sección o sección fase")]
        public string SeccionId { get; set; }


        [DisplayName("El rol")]
        public string RolId { get; set; }

    }
}
