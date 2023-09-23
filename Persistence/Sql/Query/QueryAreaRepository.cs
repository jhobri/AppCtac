using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Area;
using Back.Ctac.Query.Area;
using Minedu.Fw.NetConnect.SQL;
using System.Data;
namespace Back.Ctac.Data.Query;
public class QueryAreaRepository : QueryGenericRepository, IQueryAreaRepository
{
    public QueryAreaRepository(string connectionString) : base(connectionString)
    {
    }


    public async Task<IEnumerable<USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR_Result>> GetAreasDesaprobadosEstudiantesByIeEvaluadorAsync(AreasDesaprobadosEstudiantesRequest entity)
    {
        var parm = new Parameter[]
                   {
                    new Parameter("@COD_MOD", entity.CodigoModular),
                    new Parameter("@ANEXO", entity.Anexo),
                    new Parameter("@ID_ANIO", entity.Anio),
                    new Parameter("@ID_GRADO", entity.GradoId),
                   };

        var results = await ExecuteReaderAsync<USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR_Result>(Procedure.Query.USP_SEL_ESTUDIANTE_AREA_DESPROBADO_BY_IE_EVALUADOR, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return results;
    }


}
