using AutoMapper;
using Back.Ctac.Dto.Fruta;
using Back.Ctac.IApplication.UseCases;
using Back.Ctac.Rest.Service.Fruta;
using MediatR;

namespace Back.Ctac.Application.UseCases;

public class FrutaApplication : GenericApplication, IFrutaApplication
{

    private readonly IFrutaApiGateway _application;
    public FrutaApplication(IMapper mapper, IMediator mediator, IFrutaApiGateway application) : base(mapper, mediator)
    {
        _application = application;
    }

    public async Task<IEnumerable<GetFrutaLstResponse>> GetFrutaLst()
    {
        using (var httpclient = new HttpClient())
        {
            using (var response = await httpclient.GetAsync("https://ws.rita.com.pe/api/listar_frutas"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
               // var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(apiResponse);

            }
        }

        var respons = await _application.GetFrutas();

        return Enumerable.Empty<GetFrutaLstResponse>();

    }
    /*
public async Task<IEnumerable<GetResponsableLstResponse>> GetResponsableLst(GetResponsableLstRequest request)
{
   var responsablesRest = (await _application.ListarResponsableMatricula(new PersonalIEPorAnioRequestDto()
   {
       CodigoModular = request.CodigoModular,
       Anexo = request.Anexo,
       Anio = request.Anio
   })).GetArray<PersonalIEPorAnioResponseDto>();

   if (!responsablesRest.Any())
       return Enumerable.Empty<GetResponsableLstResponse>();

   return responsablesRest.Select(r => new GetResponsableLstResponse()
   {
       Id = r.Id,
       ApellidosNombres = r.ApellidosNombres
   });

}*/
}
