using Back.Ctac.Dto.Base;
using Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel;
using System.ComponentModel;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel
{
    public class PostExcelEvaluacionPeriodoNotaTestRequestDto : InstitucionEducativaAnioBaseRequestDto
    {
        [DisplayName("El período promocional")]
        public int? PeriodoPromocionalId { get; set; }

        [DisplayName("El período académico")]
        public string PeriodoId { get; set; }

        [DisplayName("La sección o sección fase")]
        public string SeccionId { get; set; }

        [DisplayName("El Grado")]
        public string GradoId { get; set; }

        [DisplayName("El rol")]
        public string RolId { get; set; }

        public string NivelId { get; set; }
        public string DisenioId { get; set; }
        public string FaseId { get; set; }
        public string ModalidadId { get; set; }
        public int? PeriodoPromocionalEquivalenciaId { get; set; }
        public List<AreaExcelReadResponseDto> lstArea { get; set; }
    }
}