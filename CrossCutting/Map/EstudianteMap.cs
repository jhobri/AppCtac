using AutoMapper;
using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Query.Estudiante.ByIdSeccionEstudiante;
using Back.Ctac.Query.Estudiante.ByIeEvaluador;
using Back.Ctac.Query.Estudiante.ByIeEvaluadorMultiple;

namespace Back.Ctac.Map;

public class EstudianteMap : Profile
{
    public EstudianteMap()
    {
        CreateMap<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE_Result, EstudianteEvaluacionResponse>()
           .ForMember(des => des.EstudianteSeccionId, opt => opt.MapFrom(src => src.ID_ESTUDIANTE_SECCION))
           .ForMember(des => des.CodigoModular, opt => opt.MapFrom(src => src.COD_MOD))
           .ForMember(des => des.CodigoModularEvaluacion, opt => opt.MapFrom(src => src.COD_MOD_EVALUACION))
           .ForMember(des => des.SeccionId, opt => opt.MapFrom(src => src.ID_SECCION))
           .ForMember(des => des.SeccionEvaluacionId, opt => opt.MapFrom(src => src.ID_SECCION_EVALUACION))
           .ForMember(des => des.PersonaId, opt => opt.MapFrom(src => src.ID_PERSONA));

        CreateMap<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_Result, EstudianteEvaluacionByIeResponse>()
          .ForMember(des => des.EstudianteSeccionId, opt => opt.MapFrom(src => src.ID_ESTUDIANTE_SECCION))
          .ForMember(des => des.CodigoModular, opt => opt.MapFrom(src => src.COD_MOD))
          .ForMember(des => des.CodigoModularEvaluacion, opt => opt.MapFrom(src => src.COD_MOD_EVALUACION))
          .ForMember(des => des.SeccionId, opt => opt.MapFrom(src => src.ID_SECCION))
          .ForMember(des => des.SeccionEvaluacionId, opt => opt.MapFrom(src => src.ID_SECCION_EVALUACION))
          .ForMember(des => des.PersonaId, opt => opt.MapFrom(src => src.ID_PERSONA));


        CreateMap<USP_SEL_ESTUDIANTES_SECCION_BY_ID_Result, EstudianteSeccionResponse>()
         .ForMember(des => des.EstudianteSeccionId, opt => opt.MapFrom(src => src.ID_ESTUDIANTE_SECCION))
         .ForMember(des => des.CodigoModular, opt => opt.MapFrom(src => src.COD_MOD))
         .ForMember(des => des.CodigoModularEvaluacion, opt => opt.MapFrom(src => src.COD_MOD_EVALUACION))
         .ForMember(des => des.SeccionId, opt => opt.MapFrom(src => src.ID_SECCION))
         .ForMember(des => des.SeccionEvaluacionId, opt => opt.MapFrom(src => src.ID_SECCION_EVALUACION))
         .ForMember(des => des.PersonaId, opt => opt.MapFrom(src => src.ID_PERSONA))
         .ForMember(des => des.NivelId, opt => opt.MapFrom(src => src.ID_NIVEL))
         .ForMember(des => des.Anexo, opt => opt.MapFrom(src => src.ANEXO))
         .ForMember(des => des.Fecha, opt => opt.MapFrom(src => src.FECHA_RESOLUCION))
         .ForMember(des => des.Resolucion, opt => opt.MapFrom(src => src.NRO_RESOLUCION))


         ;


    }
}