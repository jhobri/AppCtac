
using Back.Ctac.Command.AutorizacionEvaluacion;
using Back.Ctac.Data.Setting;
using Back.Ctac.Domain.Estudiante;
using Back.Ctac.Domain.General;
using Minedu.Fw.NetConnect.SQL;
using System.Data;


namespace Back.Ctac.Data.Command;

public class CommandAutorizacionEvaluacionRepository : CommandGenericRepository, ICommandAutorizacionEvaluacionRepository
{
    public CommandAutorizacionEvaluacionRepository(string connectionString) : base(connectionString)
    {
    }



    public async Task<GenericCommandResult<int>> UpdAutorizacionAsync(USP_UPD_AUTORIZACION_EVALUACION_EXTERNA_Request entity)
    {


        var parm = new Parameter[]
        {

                new Parameter("@ID_ESTUDIANTE_SECCION", entity.ID_ESTUDIANTE_SECCION),
                new Parameter("@COD_MOD_EVALUACION", entity.COD_MOD_EVALUACION),
                new Parameter("@RESOLUCION", entity.NRO_RESOLUCION),
                new Parameter("@FECHA", entity.FECHA_RESOLUCION),
                new Parameter("@USUARIO", entity.USUARIO_REGISTRA)
        };
        var result = await ExecuteScalarAsync<int>(Procedure.Command.USP_UPD_AUTORIZACION_EVALUACION_EXTERNA, CommandType.StoredProcedure, parm, _commandTimeOutSeconds);
        return new GenericCommandResult<int>() { Result = result };
    }
}
