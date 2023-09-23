using Back.Ctac.Dto.Base;
using FluentValidation;


namespace Back.Ctac.Api.Validator.Base;

public class InstitucionEducativaAnioBaseRequestDtoValidator : AbstractValidator<InstitucionEducativaAnioBaseRequestDto>
{
    public InstitucionEducativaAnioBaseRequestDtoValidator()
    {
        RuleFor(x => x.Anio)
             .Cascade(CascadeMode.Stop)
             //.NotNull().WithMessage(GlobalMessages.Required.Anio)
             //.Must(p => GlobalValidator<short>.IsValidAnioAcademico(p)).WithMessage(GlobalMessages.Format.Anio)
             ;
    }
}
