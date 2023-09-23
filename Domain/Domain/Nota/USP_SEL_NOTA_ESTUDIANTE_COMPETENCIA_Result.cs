namespace Back.Ctac.Domain.Nota;

public class USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result
{
    public int ID_ESTUDIANTE_SECCION { set; get; }
    public int ID_PERSONA { set; get; }
    public string ID_AREA { set; get; }
    public string ID_COMPETENCIA { set; get; }
    public string NOTA { set; get; }
    public string CONCLUSION_DESCRIPTIVA { set; get; }
    public bool ES_EDITABLE { get; set; }
}
