using Back.Ctac.Query.Base;

namespace Back.Ctac.Query.Estudiante.ByIeEvaluador;

public class EstudianteEvaluacionByIeRequest : IeBase
{
    public string GradoId { get; set; }
}