using AutoMapper;
using Back.Ctac.Domain.Ie;
using Back.Ctac.Query.Ie.ByAnio;

namespace Back.Ctac.Map
{
    public class IeEvaluacionMap : Profile
    {
        public IeEvaluacionMap()
        {

            CreateMap<USP_SEL_IE_EVALUACION_BY_ANIO_Result, IeEvaluacionResponse>()
              .ForMember(des => des.CodigoModular, opt => opt.MapFrom(src => src.COD_MOD))
              .ForMember(des => des.Anexo, opt => opt.MapFrom(src => src.ANEXO))
              .ForMember(des => des.Anio, opt => opt.MapFrom(src => src.ID_ANIO))
              .ForMember(des => des.NivelId, opt => opt.MapFrom(src => src.ID_NIVEL))
              .ForMember(des => des.IeEvaluacionId, opt => opt.MapFrom(src => src.ID_IE_EVALUACION))
              .ForMember(des => des.EstadoCierreAnual, opt => opt.MapFrom(src => src.ESTADO_CIERRE_IE))
              ;


        }

    }
}
