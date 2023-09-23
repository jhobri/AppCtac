namespace Back.Ctac.Api.ViewModel.PeriodoEvaluacion
{
    public class InstitucionEducativaPeriodoModel
    {
        public int IdIeEvaluacionPeriodoPromocional { get; set; }
        public int IdIeEvaluacion { get; set; }
        public int IdPeriodoPromocional { get; set; }
        public short EstadoEvaluacion { get; set; }
        public bool Migrado { get; set; }
    }
}
