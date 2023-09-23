
using Back.Ctac.Dto.Base;

namespace Back.Ctac.Dto.InstitucionEducativaGeneral;

public class GetInstitucionEducativaGeneralResponse
{
    public ItemBase<string> PeriodoTipo { get; set; }
    public InstitucionEducativaEvaluacionRectificacion Rectificacion { get; set; }
    public InstitucionEducativaEvaluacion Postergacion { get; set; }
    public InstitucionEducativaEvaluacionPeriodo Periodo { get; set; }
}

public class InstitucionEducativaEvaluacionRectificacion
{
    public ItemBase<short> Estado { get; set; }
    public bool Evaluable { get; set; }
    public ItemBase<string> Tipo { get; set; }
    public ItemBase<short> Motivo { get; set; }
    public string Observacion { get; set; }
}

public class InstitucionEducativaEvaluacion
{
    public ItemBase<short> Estado { get; set; }
}
public class InstitucionEducativaEvaluacionPeriodo
{
    public ItemBase<short> Estado { get; set; }
    public ItemBase<short> Registro { get; set; }
}