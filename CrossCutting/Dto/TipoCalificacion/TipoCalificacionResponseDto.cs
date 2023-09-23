namespace Back.Ctac.Dto.TipoCalificacion
{
    public class TipoCalificacionResponseDto
    {
        public string Codigo { get; set; }

        public bool ValidarConclusionDescripcion { get; set; }

        public string Descripcion { get; set; }
        public bool EsRequeridoNota { get; set; }
        public bool EsReemplazable { get; set; }
    }
}
