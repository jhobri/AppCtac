using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Dto.Publicidad
{
    public class GetPublicidadResponseDto
    {
        public int id_publicidad { get; set; }
        public string nombre_publicidad { get; set; }
        public short estado_publicidad { get; set; } 
        public string fecha_registro { get; set; }
    }
}
