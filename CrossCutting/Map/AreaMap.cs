using AutoMapper;
using Back.Ctac.Domain;
using Back.Ctac.Domain.Area;
using Back.Ctac.Dto;
using Back.Ctac.Query.Area;

namespace Back.Ctac.Map;

public class AreaMap : Profile
{
    public AreaMap()
    {
        CreateMap<USP_SEL_GRADO_AREA_RESPONSABLE_Result, GetAreaResponsableLstResponse>()
           .ForMember(des => des.IdArea, opt => opt.MapFrom(src => src.ID_AREA.Trim()))
           .ForMember(des => des.IdPersona, opt => opt.MapFrom(src => src.ID_PERSONA))

           ;


        CreateMap<USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR_Result, AreasDesaprobadosEstudiantesResponse>()
           .ForMember(des => des.AreaId, opt => opt.MapFrom(src => src.ID_AREA.Trim()))
           .ForMember(des => des.PersonaId, opt => opt.MapFrom(src => src.ID_PERSONA))

           ;
    }

}
