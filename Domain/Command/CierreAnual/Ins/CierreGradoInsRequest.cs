using Back.Ctac.Command.General;

namespace Back.Ctac.Command.CierreAnual.Ins;

public class CierreGradoInsRequest
{
    public string CodigoModular { get; set; }
    public string Anexo { get; set; }
    public short Anio { get; set; }
    public string Usuario { get; set; }
    public string RolId { get; set; }

    public IEnumerable<GradoCierreIns> Grados { get; set; }
}

public class GradoCierreIns : BaseValidRequest
{
    public int Id { get; set; }

    public string Codigo { get; set; }

    public string Nombre { get; set; }
}