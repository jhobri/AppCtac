using Back.Ctac.Dto.Base;
using System.ComponentModel;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel
{
    public class GetExcelEvaluacionRecuperacionRequestDto : InstitucionEducativaAnioBaseRequestDto
    {

        [DisplayName("El Grado")]
        public string GradoId { get; set; }
    }
}
