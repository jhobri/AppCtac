using AutoMapper;
using Back.Ctac.Dto.Publicidad;
using Back.Ctac.IApplication.UseCases.Publicidad;
using MediatR;
using Minedu.Fw.General.Response.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Application.UseCases.Publicidad
{
    public class PublicidadApplication : GenericApplication, IPublicidadApplication
    {


        public PublicidadApplication(
            IMapper mapper
            , IMediator mediator
            ) :  base(mapper, mediator)
        {
           
        }
        public async Task<IEnumerable<GetPublicidadResponseDto>> getPublicidad()
        {

            var publidad = new List<GetPublicidadResponseDto>();
            return publidad;
        }

        public async Task<StatusResponse<GetPublicidadResponseDto>> getPublicidadById(GetPublicidadResponseRequest request)
        {
            var response = new StatusResponse<GetPublicidadResponseDto>();
            return response;
        }
    }
}
