using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Grado;
using Back.Ctac.Query.Grado;
using Back.Ctac.Query.Grado.ByIe;
using Minedu.Fw.NetConnect.SQL;
using System.Data;
namespace Back.Ctac.Data.Query;
public class QueryGradoRepository : QueryGenericRepository, IQueryGradoRepository
{
    public QueryGradoRepository(string connectionString) : base(connectionString)
    {
    }


    public async Task<IEnumerable<USP_SEL_GRADO_BY_IE_Result>> GetByIeAsync(GradoRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                   };

        var results = await ExecuteReaderAsync<USP_SEL_GRADO_BY_IE_Result>(Procedure.Query.USP_SEL_GRADO_BY_IE, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }


}
