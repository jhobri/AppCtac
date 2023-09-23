namespace Back.Ctac.Domain.Estudiante;

public class USP_UPD_AUTORIZACION_EVALUACION_EXTERNA_Request
{
    public int ID_ESTUDIANTE_SECCION { get; set; }
    public string COD_MOD_EVALUACION { get; set; }
    public string NRO_RESOLUCION { get; set; }
    public DateTime? FECHA_RESOLUCION { get; set; }
    public string USUARIO_REGISTRA { get; set; }



}
