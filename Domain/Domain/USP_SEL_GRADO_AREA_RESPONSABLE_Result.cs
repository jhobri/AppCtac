using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Domain
{
    public class USP_SEL_GRADO_AREA_RESPONSABLE_Result
    {
        public int ID_GRADO_AREA_RESPONSABLE { get; set; }
        public string COD_MOD { get; set; }
        public string ANEXO { get; set; }
        public short ID_ANIO { get; set; }
        public string ID_NIVEL { get; set; }
        public string ID_GRADO { get; set; }
        public string ID_AREA { get; set; }
        public int ID_PERSONA { get; set; }
        public bool ESTADO_REGISTRO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_CREACION { get; set; }
    }
}
