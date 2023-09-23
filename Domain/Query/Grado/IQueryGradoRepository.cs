
using Back.Ctac.Domain.Grado;
using Back.Ctac.Query.Grado.ByIe;

namespace Back.Ctac.Query.Grado;

public interface IQueryGradoRepository
{

    Task<IEnumerable<USP_SEL_GRADO_BY_IE_Result>> GetByIeAsync(GradoRequest entity);
}