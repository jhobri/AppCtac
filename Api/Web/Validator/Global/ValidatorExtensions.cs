using FluentValidation;


namespace Back.Ctac.Api.Validator.Global;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, TProperty> InValues<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params TProperty[] validOptions)
    {
        string valores;
        if (validOptions == null || validOptions.Length == 0)
        {
            throw new ArgumentException("Valor requerido.", nameof(validOptions));
        }
        else if (validOptions.Length == 1)
        {
            valores = validOptions[0].ToString();
        }
        else
        {
            valores = $"{string.Join(", ", validOptions.Select(vo => vo.ToString()).ToArray(), 0, validOptions.Length - 1)} o {validOptions.Last()}";
        }

        return ruleBuilder
            .Must(validOptions.Contains)
            .WithMessage($"{{PropertyName}}: El valor ingresado no es válido. Rango de valores permitidos es {valores}");
    }
}
