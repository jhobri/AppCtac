using Back.Ctac.Dto.Publicidad;
using Minedu.Fw.General.Response.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.IApplication.UseCases.Publicidad
{
    public interface IPublicidadApplication
    {
        Task<IEnumerable<GetPublicidadResponseDto>> getPublicidad();
        Task<StatusResponse<GetPublicidadResponseDto>> getPublicidadById(GetPublicidadResponseRequest request);
    }
}
