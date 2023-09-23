using Minedu.Fw.NetConnect.SQL;
using System.Data;
using Back.Ctac.Domain.Ie;
using Back.Ctac.Query.Ie;
using Back.Ctac.Query.Ie.ByAnio;
using Back.Ctac.Data.Setting;

namespace Back.Ctac.Data.Query;

public class QueryIeEvaluacionRepository : QueryGenericRepository, IQueryIeEvaluacionRepository
{
    public QueryIeEvaluacionRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<USP_SEL_IE_EVALUACION_BY_ANIO_Result> GetByAnioAsync(IeEvaluacionRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio)
                   };

        var results = await ExecuteReaderAsync<USP_SEL_IE_EVALUACION_BY_ANIO_Result>(Procedure.Query.USP_SEL_IE_EVALUACION_BY_ANIO, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results.FirstOrDefault();
    }
}