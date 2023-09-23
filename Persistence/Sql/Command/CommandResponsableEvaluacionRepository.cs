using Back.Ctac.Command.ResponsableEvaluacion;
using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.General;
using Back.Ctac.Domain.ResponsableEvaluacion;
using Minedu.Fw.General.Extension;
using Minedu.Fw.NetConnect.SQL;
using System.Data;

namespace Back.Ctac.Data.Command
{
    public class CommandResponsableEvaluacionRepository : CommandGenericRepository, ICommandResponsableEvaluacionInsRepository
    {
        public CommandResponsableEvaluacionRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<GenericCommandResult<int>> InsertAsync(USP_INS_GRADO_AREA_RESPONSABLE_Request entity)
        {
            var areas = GenericType.ToDataTable(entity.AREAS.ToList());

            var parm = new Parameter[]
            {
                new Parameter("@COD_MOD", entity.COD_MOD),
                new Parameter("@ANEXO", entity.ANEXO),
                new Parameter("@ID_ANIO", entity.ID_ANIO),
                new Parameter("@ID_NIVEL", entity.ID_NIVEL),
                new Parameter("@ID_GRADO", entity.ID_GRADO),
                new Parameter("@USUARIO", entity.USUARIO),

                new Parameter("@TYPE_AREA_RESPONSABLE", areas),
            };
            var result = await ExecuteScalarAsync<int>(Procedure.Command.USP_INS_GRADO_AREA_RESPONSABLE, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
            return new GenericCommandResult<int>() { Result = result };
        }
    }
}
