namespace Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel
{
    public partial class AreaExcelReadResponseDto

    {
        public string Id { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public bool EsTaller { get; set; }
        public IEnumerable<EstudianteExcelReadResponseDto> estudiantes { set; get; }
        public IEnumerable<CompetenciaExcelReadResponseDto> competencias { set; get; }

    }

    public partial class CompetenciaExcelReadResponseDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }

    }
    public partial class ComentarioExcelReadResponseDto
    {
        public int EstudianteId { get; set; }
        public string Comentario { get; set; }

    }
    public partial class EstudianteExcelReadResponseDto
    {

        /// <summary>
        /// Id=IdPersona
        /// </summary>
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public bool EsExonerado { set; get; }
        public bool EsTallerBloqueado { set; get; }
        public IEnumerable<NotaExcelReadResponseDto> notas { set; get; }

        //public int IdEstudiantePorSeccion { get; set; }
        //public int IdSeccion { get; set; }
    }
    public partial class NotaExcelReadResponseDto
    {


        public string Id { get; set; }
        public string Nota { get; set; }
        public string Conclusion { get; set; }
        public bool EsExonerado { set; get; }

    }
    public partial class TipoRecuperacionExcelReadResponseDto
    {
        public int EstudianteId { get; set; }
        public string EstudianteCodigo { get; set; }
        public string EstudianteNombres { get; set; }
        public string TipoRecuperacion { get; set; }

    }
}
