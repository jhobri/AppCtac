using Minedu.Fw.Domain.SeedWork;


namespace Back.Ctac.Transversal.Validations;

public class CustomException : Entity, IAggregateRoot
{

    public static void Excepcion(string msj, string accion)
    {
        ApplyRule(new CustomExceptionRuler(msj, accion));
    }
}
