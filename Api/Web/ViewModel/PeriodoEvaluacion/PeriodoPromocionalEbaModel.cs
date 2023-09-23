namespace Back.Ctac.Api.ViewModel.PeriodoEvaluacion
{
    public class PeriodoEvaluacionEbaModel //: PeriodoEvaluacionModel
    {
        // public int PeriodoPromocionalId { get; set; }
        //  public string PeriodoPromocionalNombre { get; set; }
        //   public int FasePeriodoPromocionalId { get; set; }
        public PeriodoPromocionalModel PeriodoPromocional { get; set; }

        public FaseModel Fase { get; set; }

        public IEnumerable<PeriodoEvaluacionModel> PeriodosEvaluacion { get; set; }
    }
}