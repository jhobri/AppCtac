using AutoMapper;
using Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel;
using Back.Ctac.Transversal.Functions;
using Minedu.Siagie.Model.Internal;

namespace Back.Ctac.Map.Recepion.Nota
{

    public class RecepcionNotaEstudianteMap : Profile
    {
        public RecepcionNotaEstudianteMap()
        {
            CreateMap<AreaExcelReadResponseDto, AreaEvaluacionPeriodoDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id.TrimCustom()))
                   .ForMember(des => des.Abreviatura, opt => opt.MapFrom(src => src.Abreviatura.TrimCustom()))
                   .ForMember(des => des.EsTaller, opt => opt.MapFrom(src => src.EsTaller))
                   .ForMember(des => des.estudiantes, opt => opt.MapFrom(src => src.estudiantes))
                   .ForMember(des => des.competencias, opt => opt.MapFrom(src => src.competencias));

            CreateMap<CompetenciaExcelReadResponseDto, CompetenciaEvaluacionPeriodoDto>()
              .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id.TrimCustom()));

            CreateMap<EstudianteExcelReadResponseDto, EstudianteEvaluacionPeriodoDto>()
                       .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                       .ForMember(des => des.Codigo, opt => opt.MapFrom(src => src.Codigo))
                       .ForMember(des => des.Nombres, opt => opt.MapFrom(src => src.Nombres))
                       .ForMember(des => des.EsTallerBloqueado, opt => opt.MapFrom(src => src.EsTallerBloqueado))
                       .ForMember(des => des.EsExonerado, opt => opt.MapFrom(src => src.EsExonerado))
                       .ForMember(des => des.notas, opt => opt.MapFrom(src => src.notas));

            CreateMap<NotaExcelReadResponseDto, NotaEvaluacionPeriodoDto>()
                        .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(des => des.Nota, opt => opt.MapFrom(src => src.Nota.TrimCustom()))
                          .ForMember(des => des.EsExonerado, opt => opt.MapFrom(src => src.EsExonerado))
                        .ForMember(des => des.Conclusion, opt => opt.MapFrom(src => src.Conclusion.TrimCustom()));
        }
    }
}
