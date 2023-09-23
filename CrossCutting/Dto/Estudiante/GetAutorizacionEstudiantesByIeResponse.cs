namespace Back.Ctac.Dto.Estudiante;

public class GetAutorizacionEstudiantesByIeResponse
{


    public GetAutorizacionEstudiantesByIeResponse()
    {
        Areas = new List<string>();
    }
    public int EstudianteSeccionId { get; set; }
    public int PersonaId { get; set; }
    public string ApellidosNombres { get; set; }
    //public string ApellidoPaterno { get; set; }
    //public string ApellidoMaterno { get; set; }
    //public string Nombres { get; set; }
    public string DescripcionSeccion { get; set; }
    public short TipoEvaluacion { get; set; }

    public int CantidadAreaDesaprobado { get; set; }

    public IEnumerable<string> Areas { get; set; }

    public IEnumerable<string> AreasCargo { get; set; }
}
