

using Back.Ctac.Dto.Base;

namespace Back.Ctac.Dto.CierreAnual;

public class PostCierreAnualGradoRequest : InstitucionEducativaAnioBaseRequestDto
{
    public IEnumerable<GradoIdsRequest> Grados { get; set; }
}
