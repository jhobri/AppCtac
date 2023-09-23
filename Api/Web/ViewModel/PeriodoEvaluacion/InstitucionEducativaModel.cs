namespace Back.Ctac.Api.ViewModel.PeriodoEvaluacion
{
    public class InstitucionEducativaModel
    {
        public int Id { get; set; }
        public string CodigoModular { get; set; }
        public string Anexo { get; set; }
        public short Anio { get; set; }
        public short Cierre { get; set; }
        public bool Migrado { get; set; }
    }
}
