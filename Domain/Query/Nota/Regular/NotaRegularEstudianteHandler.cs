using AutoMapper;
using Back.Ctac.Dto.Nota;
using Back.Ctac.Query;
using Back.Ctac.Transversal.Functions;
using MediatR;

namespace Back.Ctac.Query.Nota.Regular;

public class NotaRegularEstudianteHandler : IRequestHandler<NotaRegularEstudianteQuery, IEnumerable<NotaEstudianteResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public NotaRegularEstudianteHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotaEstudianteResponse>> Handle(NotaRegularEstudianteQuery request, CancellationToken cancellationToken)
    {

        var result = await _uow.NotaEstudianteRepository.GetNotaRegularEstudiante(request.entity);

        var response = result.Select(x => new NotaEstudianteResponse
        {
            EstudianteSeccionId = x.ID_ESTUDIANTE_SECCION,
            PersonaId = x.ID_PERSONA,
            AreaId = x.ID_AREA.TrimCustom(),
            CompetenciaId = x.ID_COMPETENCIA.TrimCustom(),
            Nota = x.NOTA.TrimCustom(),
            ConclusionDescriptiva = x.CONCLUSION_DESCRIPTIVA.TrimCustom(),
            EsEditable = x.ES_EDITABLE
        });


        return response;


    }


}