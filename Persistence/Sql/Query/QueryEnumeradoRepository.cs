using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Enumerado;
using Back.Ctac.Query.Enumerado;
using Minedu.Fw.NetConnect.SQL;
using System.Data;

namespace Back.Ctac.Data.Query;

public class QueryEnumeradoRepository : QueryGenericRepository, IQueryEnumeradoRepository
{
    public QueryEnumeradoRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<USP_SEL_ENUMERADO_Result>> GetAsync(string entity)
    {
        var parm = new Parameter[]
        {
                new Parameter("@NOMBRE_ENUMERADO",entity),
        };
        var result = await ExecuteReaderAsync<USP_SEL_ENUMERADO_Result>(Procedure.Query.USP_SEL_ENUMERADO_BY_TIPO, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return result;
    }
}