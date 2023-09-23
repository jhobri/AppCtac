namespace Back.Ctac.Api.ViewModel.PeriodoEvaluacion
{
    public class PeriodoEvaluacionEbrModel
    {
        public string TipoNombre { get; set; }
        public string TipoId { get; set; }
        public IEnumerable<PeriodoEvaluacionModel> Periodos { get; set; }
    }
}