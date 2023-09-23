using Minedu.Fw.Domain.SeedWork;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Query.Excepcion;

public class GenerarException : Entity, IAggregateRoot
{
    internal static void ExcepcionMany(string msj, string accion)
    {
        var data = new List<MessageStatusResponse>();
        data.Add(new MessageStatusResponse(msj));
        ApplyRule(new ExcepcionManyRule(data, accion));
    }

    internal static void Excepcion(string msj, string accion)
    {
        ApplyRule(new ExcepcionRule(msj, accion));
    }
}
