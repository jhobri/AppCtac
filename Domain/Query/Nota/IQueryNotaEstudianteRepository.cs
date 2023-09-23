
using Back.Ctac.Domain.Nota;
using Back.Ctac.Query.Nota.Recuperacion;
using Back.Ctac.Query.Nota.Regular;

namespace Back.Ctac.Query.Nota;

public interface IQueryNotaEstudianteRepository
{
    Task<IEnumerable<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>> GetNotas(NotaEstudianteRequest entity);

    Task<IEnumerable<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>> GetNotaRegularEstudiante(NotaRegularEstudianteRequest entity);

}