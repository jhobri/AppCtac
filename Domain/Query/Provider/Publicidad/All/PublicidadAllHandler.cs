using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Query.Provider.Publicidad.All
{
 
    //public class PublicidadAllHandler : IRequestHandler<object? request, PublicidadAllResponse>
    //{
    //    private readonly IQueryUnitOfWork _uow;
    //    protected readonly IMapper _mapper;

    //    public PublicidadAllHandler(IQueryUnitOfWork uow, IMapper mapper)
    //    {
    //        _uow = uow;
    //        _mapper = mapper;
    //    }
    //    public async Task<IEnumerable<PublicidadAllResponse>> Handle(CancellationToken cancellationToken)
    //    {
    //        var result = await _uow.InstitucionEducativaRepository.ByIe(new IeEvaluacion() { CodigoModular = request.entity.CodigoModular, Anexo = request.entity.Anexo, Anio = request.entity.Anio });
    //        return _mapper.Map<USP_SEL_IE_EVALUACION_Result, EvaluacionByAnioResponse>(result);
    //    }
    //}
}
