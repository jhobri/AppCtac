namespace Back.Ctac.Rest.Service.Proxy.Model.Fruta
{
    public class PostProcesoRequest
    {
        public int tipoProcesoId { set; get; }
        public int tipoSubProcesoId { set; get; }
        public string codigoModular { set; get; }
        public string anexo { set; get; }
        public short anio { set; get; }
        public string nivelId { set; get; }
        public string disenioId { set; get; }
        public string periodoId { set; get; }
        public string faseId { set; get; }
        public string gradoId { set; get; }
        public string seccionId { set; get; }
        public string nombreArchivo { set; get; }
        public string usuario { set; get; }
        public string RolId { set; get; }
        public int PeriodoPromocionalId { get; set; } = 0;
        public FrutaRequest etapa { set; get; }
    }
}