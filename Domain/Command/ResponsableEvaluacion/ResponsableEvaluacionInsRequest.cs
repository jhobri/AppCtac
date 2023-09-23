namespace Back.Ctac.Command.ResponsableEvaluacion
{
    public class ResponsableEvaluacionInsRequest
    {
        public string CodigoModular { get; set; }
        public string Anexo { get; set; }
        public short Anio { get; set; }
        public string Nivel { get; set; }
        public string Grado { get; set; }
        public string Usuario { get; set; }
        public string RolId { get; set; }
        public IEnumerable<AreaResponsableInsRequest> Areas { get; set; }
    }
    public class AreaResponsableInsRequest
    {
        public string IdArea { get; set; }
        public int IdPersona { get; set; }
    }
}
