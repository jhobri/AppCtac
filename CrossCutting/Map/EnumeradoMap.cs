

using AutoMapper;
using Back.Ctac.Domain.Enumerado;
using Back.Ctac.Query.Enumerado;

namespace Back.Ctac.Map;

public class EnumeradoMap : Profile
{
    public EnumeradoMap()
    {
        CreateMap<USP_SEL_ENUMERADO_Result, EnumeradoResponse>()
           .ForMember(des => des.Id, opt => opt.MapFrom(src => src.CODIGO_ENUMERADO))
           .ForMember(des => des.Nombre, opt => opt.MapFrom(src => src.VALOR_ENUMERADO))
           .ForMember(des => des.Descripcion, opt => opt.MapFrom(src => src.DESCRIPCION_ENUMERADO))
           ;
    }
}
