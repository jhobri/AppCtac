namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest
{
    public class Institucion
    {
        public List<InstitucionModel> instituciones { get; set; }
    }

    public class InstitucionModel
    {
        public string CodigoModular { get; set; }
        public string Anexo { get; set; }
        public short Anio { get; set; }
        public string Periodo { get; set; }
        public string PeriodoPromocionalAlias { get; set; }
        public int PeriodoEvaluacionAlias { get; set; }
    }
}