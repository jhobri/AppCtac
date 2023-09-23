using Back.Ctac.Dto.InstitucionEducativaGeneral;
using Back.Ctac.Transversal.Functions;
using FluentValidation;

namespace Back.Ctac.Api.Validator.General;

public class GetInstitucionEducativaGeneralRequestValidator : AbstractValidator<GetInstitucionEducativaGeneralRequest>
{
    public GetInstitucionEducativaGeneralRequestValidator()
    {
        RuleFor(x => x)
        .Must((model, propertyValue, context) =>
        {
            model.CodigoModular = model.CodigoModular.TrimUpper();
            model.Anexo = model.Anexo.TrimUpper();
            return true;
        });

        //Include(new InstitucionEducativaAnioBaseRequestDtoValidator());
        //Include(new InstitucionEducativaBaseRequestDtoValidator());

        //RuleFor(x => x.RolId)
        // .Cascade(CascadeMode.Stop)
        // //.Must(p => GlobalValidator<string>.IsNotNullOrEmpty(p)).WithMessage(GlobalMessages.Required.RolId)
        // //.Must(p => GlobalValidator<string>.IsRol(p)).WithMessage(GlobalMessages.Format.RolId)
        // .When(p => !string.IsNullOrWhiteSpace(p.RolId.TrimCustom()));
    }
}