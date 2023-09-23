using Back.Ctac.Dto.Fruta;

namespace Back.Ctac.IApplication.UseCases;

public interface IFrutaApplication
{
    Task<IEnumerable<GetFrutaLstResponse>> GetFrutaLst();
}
