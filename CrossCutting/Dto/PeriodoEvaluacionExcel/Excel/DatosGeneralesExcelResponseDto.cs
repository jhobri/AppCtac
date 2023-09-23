namespace Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel
{
    public class DatosGeneralesExcelResponseDto
    {
        public string CodigoModular { set; get; }
        public string Anexo { set; get; }
        public short Anio { set; get; }

        public string NombreIE { set; get; }
        public string NivelId { set; get; }
        public string NivelNombre { set; get; }
        public string DisenioId { set; get; }
        public string DisenioNombre { set; get; }

        public string PeriodoId { set; get; }
        public string PeriodoNombre { set; get; }
        public string GradoId { set; get; }
        public string GradoNombre { set; get; }
        public string SeccionId { set; get; }
        public string SeccionNombre { set; get; }

        public string FaseId { set; get; }
        public string FaseNombre { set; get; }

        public string PeriodoPromocionalId { set; get; }
        public string PeriodoPromocionalNombre { set; get; }
        public string PeriodoPromocionalEquivalenciaId { set; get; }

        //public string PeriodoEvalNombre { set; get; }

        #region ATRIBUTOS ADICIONALES

        public string ServerTemp { get; set; }
        public string BasePath { get; set; }
        public string PlantillaExcel { get; set; }
        public int TipoPlantilla { get; set; }
        public string TipoModalidad { get; set; }

        public bool EsTutorOrAdmin { get; set; }
        #endregion

        #region ATRIBUTOS POSTERGACIÓN
        public short TipoEvaluacion { get; set; }
        public short TipoRegistroEvaluacion { get; set; }
        #endregion


    }
}
