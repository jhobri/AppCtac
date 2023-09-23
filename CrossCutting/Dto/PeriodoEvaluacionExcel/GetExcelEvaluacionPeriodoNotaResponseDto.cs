using Back.Ctac.Dto.Estudiante;
using Back.Ctac.Dto.PeriodoEvaluacionExcel.Excel;
using Back.Ctac.Dto.TipoCalificacion;
using Back.Ctac.Dto.TipoRecuperacion;

namespace Back.Ctac.Dto.PeriodoEvaluacionExcel;

public class GetExcelEvaluacionPeriodoNotaResponseDto
{
    public DatosGeneralesExcelResponseDto datoGeneralExcel { set; get; }
    public IEnumerable<AreaExcelResponseDto> areas { get; set; }
    public IEnumerable<TipoCalificacionResponseDto> TipoCalificaciones { get; set; }
    public IEnumerable<ConclusionCalificacionResponseDto> ConclusionCalificaciones { get; set; }
    public IEnumerable<ComentarioGeneralExcelResponseDto> ComentariosGenerales { get; set; }

    #region ATRIBUTOS POSTERGACION
    public IEnumerable<AreaCompetenciasDto> CompetenciasDisables { get; set; }
    public short TipoEvaluacion { get; set; }
    #endregion
    public IEnumerable<TipoRecuperacionResponse> LstTipoRecuperacion { get; set; }
    public IEnumerable<EstudianteTipoRecuperacionResponse> LstEstudianteTipoRecuperacion { get; set; }
}
