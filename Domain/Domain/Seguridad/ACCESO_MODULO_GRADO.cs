using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Domain.Seguridad
{
    public class ACCESO_MODULO_GRADO
    {
        public int ID_CONFIGURACION_GRADO { get; set; }
        public int ID_ACCESO_MODULO { get; set; }
        public string NIVEL { get; set; }
        public string GRADO { get; set; }
        public bool ES_ACTIVO { get; set; }
        public bool ESTADO_REGISTRO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
    }
}
