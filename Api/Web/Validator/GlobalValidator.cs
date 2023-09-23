using System.Text.RegularExpressions;

namespace Back.Ctac.Api.Validator;

public class GlobalValidator<T>
{
    public static readonly Predicate<string> IsNotNullOrEmpty = (d) => !string.IsNullOrEmpty(d);
    public static readonly Predicate<string> IsNumber = (d) => d == null || new Regex(@"^\d+$").IsMatch(d);
    public static readonly Predicate<int?> IsIntPositive = (d) => d != null && d.HasValue && d > 0;
    public static readonly Predicate<int?> IsIntNotNull = (d) => d != null && d.HasValue;
    public static readonly Predicate<int?> IsNotNullInt = (d) => d != null && d.HasValue;
    public static readonly Predicate<int?> IsMayorQueCeroInt = (d) => d != null && d.Value > 0;

    public static readonly Predicate<string> IsLetterOneNumberOne = (d) => d != null && new Regex(@"^[A-Z]{1}[\d]{1}$").IsMatch(d);

    public static bool IsValidLength(string value, short min = 1, short max = 100)
    {
        if (value == null) return false;
        return value.Length >= min && value.Length <= max;
    }
    public static bool IsValidRangeDate(DateTime value, DateTime? min = null, DateTime? max = null)
    {
        if (min == null) return value.Date <= max?.Date;
        if (max == null) return value.Date >= min?.Date;
        return value.Date >= min?.Date && value.Date <= max?.Date;
    }
    public static readonly Predicate<string> IsCaracterValido = (d) => d != null && new Regex(@"^[-a-zA-ZñÑäÄëËïÏöÖüÜáéíóúÁÉÍÓÚ(º°,/;_'*""“´.:¡!¿?)\d\s]+$").IsMatch(d);

}