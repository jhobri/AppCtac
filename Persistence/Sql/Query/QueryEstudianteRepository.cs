using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Query.Estudiante;
using Back.Ctac.Query.Estudiante.ByIeEvaluador;
using Back.Ctac.Query.Estudiante.ByIeEvaluadorMultiple;
using Minedu.Fw.NetConnect.SQL;
using System.Data;

namespace Back.Ctac.Data.Query;


public class QueryEstudianteRepository : QueryGenericRepository, IQueryEstudianteRepository
{
    public QueryEstudianteRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<USP_SEL_ESTUDIANTES_SECCION_BY_ID_Result> GetByIdSeccionEstudianteAsync(int id)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@ID_ESTUDIANTE_SECCION", id)
                   };

        var results = await ExecuteReaderAsync<USP_SEL_ESTUDIANTES_SECCION_BY_ID_Result>(Procedure.Query.USP_SEL_ESTUDIANTES_SECCION_BY_ID, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results.FirstOrDefault();
    }

    public async Task<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_Result>> GetByIeEvaluadorAsync(EstudianteEvaluacionByIeRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                    new Parameter("@ID_GRADO", entity.GradoId),
                   };

        var results = await ExecuteReaderAsync<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_Result>(Procedure.Query.USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }



    public async Task<IEnumerable<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE_Result>> GetByIeEvaluadorMultipleAsync(EstudianteEvaluacionRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                    new Parameter("@ID_GRADO", entity.GradoId),
                   };

        var results = await ExecuteReaderAsync<USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE_Result>(Procedure.Query.USP_SEL_ESTUDIANTES_BY_IE_EVALUADOR_MULTIPLE, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }
}