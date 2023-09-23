using AutoMapper;
using Back.Ctac.Command.ResponsableEvaluacion;
using Back.Ctac.Domain;
using Back.Ctac.Domain.ResponsableEvaluacion;
using Back.Ctac.Dto;

namespace Back.Ctac.Map
{
    public class ResponsableEvaluacionMap : Profile
    {
        public ResponsableEvaluacionMap()
        {
            CreateMap<USP_SEL_GRADO_AREA_RESPONSABLE_Result, GetAreaResponsableLstResponse>()
               .ForMember(des => des.IdArea, opt => opt.MapFrom(src => src.ID_AREA.Trim()))
               .ForMember(des => des.IdPersona, opt => opt.MapFrom(src => src.ID_PERSONA))

               ;

            CreateMap<AreaResponsableRequest, AreaResponsableInsRequest>()
              .ForMember(des => des.IdArea, opt => opt.MapFrom(src => src.IdArea))
               .ForMember(des => des.IdPersona, opt => opt.MapFrom(src => src.IdPersona))
              ;

            CreateMap<ResponsableEvaluacionInsRequest, USP_INS_GRADO_AREA_RESPONSABLE_Request>()
              .ForMember(des => des.COD_MOD, opt => opt.MapFrom(src => src.CodigoModular))
              .ForMember(des => des.ANEXO, opt => opt.MapFrom(src => src.Anexo))
              .ForMember(des => des.ID_ANIO, opt => opt.MapFrom(src => src.Anio))
              .ForMember(des => des.ID_NIVEL, opt => opt.MapFrom(src => src.Nivel))
              .ForMember(des => des.ID_GRADO, opt => opt.MapFrom(src => src.Grado))
              .ForMember(des => des.AREAS, opt => opt.MapFrom(src => src.Areas))
              ;

            CreateMap<AreaResponsableInsRequest, AREA_RESPONSABLE_TYPE>()
              .ForMember(des => des.ID_AREA, opt => opt.MapFrom(src => src.IdArea))
              .ForMember(des => des.ID_PERSONA, opt => opt.MapFrom(src => src.IdPersona))
              ;
        }

    }
}
