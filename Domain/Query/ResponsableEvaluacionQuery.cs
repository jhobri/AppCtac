using Back.Ctac.Dto;
using MediatR;

namespace Back.Ctac.Query
{
    public class ResponsableEvaluacionQuery : IRequest<IEnumerable<GetAreaResponsableLstResponse>>
    {
        public GetAreaResponsableLstRequest entity;
        public ResponsableEvaluacionQuery(GetAreaResponsableLstRequest request)
        {
            entity = request;
        }
    }
}
