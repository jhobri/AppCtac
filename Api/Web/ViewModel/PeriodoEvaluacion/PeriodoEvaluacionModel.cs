namespace Back.Ctac.Api.ViewModel.PeriodoEvaluacion
{
    public class PeriodoEvaluacionModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string EstadoNombre { get; set; }
        public string EstadoId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}