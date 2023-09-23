namespace Back.Ctac.Rest.Service.Proxy.Model.Fruta
{
    public class GetValidacionProcesoRequest
    {


        public string CodigoModular { set; get; }
        public string anexo { set; get; }
        public short anio { set; get; }
        public string nivelId { set; get; }
        public string periodoId { set; get; }
        public string faseId { set; get; }
        public string gradoId { set; get; }
        public string seccionId { set; get; }
        public string usuario { set; get; }
        public short TipoProcesoId { set; get; }

    }
}
