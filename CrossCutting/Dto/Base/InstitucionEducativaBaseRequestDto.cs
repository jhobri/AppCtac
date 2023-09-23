using System.ComponentModel;

namespace Back.Ctac.Dto.Base;

public class InstitucionEducativaBaseRequestDto : UsuarioRolBaseRequestDto
{
    [DisplayName("El código modular")]
    public string CodigoModular { get; set; }

    [DisplayName("El anexo")]
    public string Anexo { get; set; }
}