using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Domain.ResponsableEvaluacion
{
    public class USP_INS_GRADO_AREA_RESPONSABLE_Request
    {
        public string COD_MOD { get; set; }
        public string ANEXO { get; set; }
        public short ID_ANIO { get; set; }
        public string ID_NIVEL { get; set; }
        public string ID_GRADO { get; set; }
        public string USUARIO { get; set; }
        public List<AREA_RESPONSABLE_TYPE> AREAS { get; set; }
    }
    public class AREA_RESPONSABLE_TYPE
    {
        public string ID_AREA { get; set; }
        public int ID_PERSONA { get; set; }
    }
}
