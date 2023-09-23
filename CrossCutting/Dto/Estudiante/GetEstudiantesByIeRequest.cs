using Back.Ctac.Dto.Base;

namespace Back.Ctac.Dto.Estudiante;

public class GetEstudiantesByIeRequest : InstitucionEducativaAnioBaseRequestDto
{
    public string GradoId { get; set; }
}
