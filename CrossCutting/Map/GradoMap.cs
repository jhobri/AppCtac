using AutoMapper;
using Back.Ctac.Domain.Grado;
using Back.Ctac.Query.Grado.ByIe;

namespace Back.Ctac.Map;

public class GradoMap : Profile
{
    public GradoMap()
    {
        CreateMap<USP_SEL_GRADO_BY_IE_Result, GradoResponse>()
           .ForMember(des => des.GradoEvaluacionId, opt => opt.MapFrom(src => src.ID_GRADO_EVALUACION))
           .ForMember(des => des.GradoId, opt => opt.MapFrom(src => src.ID_GRADO))
           .ForMember(des => des.EstadoProcesamiento, opt => opt.MapFrom(src => src.ESTADO_PROCESAMIENTO))

           ;


    }
}