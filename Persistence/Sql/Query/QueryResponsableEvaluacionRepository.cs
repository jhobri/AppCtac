using Back.Ctac.Data.Setting;
using Back.Ctac.Domain;
using Back.Ctac.Query;
using Minedu.Fw.NetConnect.SQL;

using System.Data;

namespace Back.Ctac.Data.Query;

public class QueryResponsableEvaluacionRepository : QueryGenericRepository, IQueryResponsableEvaluacionRepository
{
    public QueryResponsableEvaluacionRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<USP_SEL_GRADO_AREA_RESPONSABLE_Result>> GetAsync(USP_SEL_GRADO_AREA_RESPONSABLE_Request entity)
    {
        var parm = new Parameter[]
             {
               new Parameter("@COD_MOD",entity.COD_MOD),
               new Parameter("@ANEXO",entity.ANEXO),
               new Parameter("@ID_ANIO",entity.ID_ANIO),
               new Parameter("@ID_NIVEL",entity.ID_NIVEL),
               new Parameter("@ID_GRADO",entity.ID_GRADO)
             };
        var result = await ExecuteReaderAsync<USP_SEL_GRADO_AREA_RESPONSABLE_Result>(Procedure.Query.USP_SEL_GRADO_AREA_RESPONSABLE, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return result;
    }
}
