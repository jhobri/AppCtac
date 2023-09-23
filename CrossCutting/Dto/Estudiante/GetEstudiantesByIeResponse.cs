namespace Back.Ctac.Dto.Estudiante;

public class GetEstudiantesByIeResponse
{



    public int EstudianteSeccionId { get; set; }
    public int PersonaId { get; set; }
    public string ApellidosNombres { get; set; }

    public string CodigoModular { get; set; }
    public string SeccionId { get; set; }
    public string DescripcionSeccion { get; set; }

    public bool EsFallecido { get; set; }
    public bool EsTrasladado { get; set; }
    public bool EsPostergado { get; set; }
    public bool EsRetirado { get; set; }
    public short EstadoMatricula { get; set; }
}
