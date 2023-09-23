namespace Back.Ctac.Domain.Seguridad
{
    public class ACCESO_MODULO
    {
        public int ID_ACCESO_MODULO { get; set; }
        public short ANIO { get; set; }
        public short ID_PROCESO { get; set; }
        public short ID_SUBPROCESO { get; set; }
        public bool ES_ACTIVO { get; set; }
        public bool ESTADO_REGISTRO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
    }
}