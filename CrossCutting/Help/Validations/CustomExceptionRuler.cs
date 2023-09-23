using Minedu.Fw.Domain.SeedWork;

namespace Back.Ctac.Transversal.Validations;

public class CustomExceptionRuler : IBusinessRule
{
    private readonly string _validation;
    private readonly string _accion;

    public CustomExceptionRuler(string validation, string accion)
    {
        _validation = validation;
        _accion = accion;

    }

    public string Message { get; set; } = string.Empty;

    public bool Failed()
    {

        if (!string.IsNullOrEmpty(_validation))
        {
            Message = $"{_validation} {_accion}";
            return true;
        }
        return false;
    }
}
