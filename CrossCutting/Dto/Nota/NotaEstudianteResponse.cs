namespace Back.Ctac.Dto.Nota;

public class NotaEstudianteResponse
{
    public string AreaId { get; set; }
    public string CompetenciaId { get; set; }
    public string ConclusionDescriptiva { get; set; }
    public string Nota { get; set; }
    public int PersonaId { set; get; }
    public bool EsEditable { set; get; }
    public int EstudianteSeccionId { get; set; }
}