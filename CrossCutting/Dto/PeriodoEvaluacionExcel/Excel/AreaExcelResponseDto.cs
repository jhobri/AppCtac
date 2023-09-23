namespace Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel
{
    public partial class AreaExcelResponseDto

    {
        public string Id { get; set; }
        public string TipoId { get; set; }

        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public bool EsTaller { get; set; }
        public bool EsCompetenciaTransversal { get; set; }

        public IEnumerable<EstudianteExcelResponseDto> estudiantes { set; get; }
        public IEnumerable<CompetenciaExcelResponseDto> competencias { set; get; }

    }


    public partial class ComentarioGeneralExcelResponseDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string Comentario { get; set; }

    }
    public partial class CompetenciaExcelResponseDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class EstudianteExcelResponseDto
    {

        /// <summary>
        /// Id=IdPersona
        /// </summary>
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public bool EsExonerado { set; get; }
        public bool EsTallerBloqueado { set; get; }
        public IEnumerable<NotaExcelResponseDto> notas { set; get; }

        //public int IdEstudiantePorSeccion { get; set; }
        //public int IdSeccion { get; set; }
    }
    public class NotaExcelResponseDto
    {


        public string Id { get; set; }
        public string Nota { get; set; }
        public string Conclusion { get; set; }
        public bool EsExonerado { set; get; }
        public bool EsEditable { get; set; }

    }
    public class AreaCompetenciasDto
    {
        public string IdArea { get; set; }
        public string IdCompetencia { get; set; }
    }




}
