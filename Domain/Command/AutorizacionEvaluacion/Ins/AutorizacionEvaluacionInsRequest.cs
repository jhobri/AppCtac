namespace Back.Ctac.Command.AutorizacionEvaluacion.Ins;

public class AutorizacionEvaluacionInsRequest
{
    public string CodigoModular { get; set; }
    public string Anexo { get; set; }
    public short Anio { get; set; }
    /*public string CodigoModularDestino { get; set; }    
    public string GradoId { get; set; }    
        */
    public int EstudianteSeccionId { get; set; }
    public string Resolucion { get; set; }
    public DateTime? Fecha { get; set; }
    public string Usuario { get; set; }
}
