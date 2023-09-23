using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Nota;
using Back.Ctac.Query.Nota;
using Back.Ctac.Query.Nota.Recuperacion;
using Back.Ctac.Query.Nota.Regular;
using Minedu.Fw.NetConnect.SQL;
using System.Data;

namespace Back.Ctac.Data.Query;
public class QueryNotaEstudianteRepository : QueryGenericRepository, IQueryNotaEstudianteRepository
{
    public QueryNotaEstudianteRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>> GetNotaRegularEstudiante(NotaRegularEstudianteRequest entity)
    {
        var parm = new Parameter[]
                  {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                    new Parameter("@ID_GRADO", entity.GradoId),
                  };

        var results = await ExecuteReaderAsync<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>(Procedure.Query.USP_SEL_NOTA_ESTUDIANTE_REGULAR_BY_IE_EVALUADOR, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }

    public async Task<IEnumerable<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>> GetNotas(NotaEstudianteRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                    new Parameter("@ID_NIVEL", entity.NivelId),
                    new Parameter("@ID_GRADO", entity.GradoId),
                   };

        var results = await ExecuteReaderAsync<USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA_Result>(Procedure.Query.USP_SEL_NOTA_ESTUDIANTE_COMPETENCIA, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }
}
