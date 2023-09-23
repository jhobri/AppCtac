using Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel;
using Back.Ctac.Dto.TipoCalificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel;

public class GetExcelEvaluacionPeriodoNotaTestResponseDto
{
    public DatosGeneralesExcelResponseDto datoGeneralExcel { set; get; }
    public List<AreaExcelReadResponseDto> areas { get; set; }
    public IEnumerable<TipoCalificacionResponseDto> TipoCalificaciones { get; set; }
    public IEnumerable<ConclusionCalificacionResponseDto> ConclusionCalificaciones { get; set; }
    public IEnumerable<ComentarioGeneralExcelResponseDto> ComentariosGenerales { get; set; }
}
