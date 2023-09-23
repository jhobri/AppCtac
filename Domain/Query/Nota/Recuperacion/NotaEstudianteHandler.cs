using AutoMapper;
using Back.Ctac.Dto.Nota;
using Back.Ctac.Query;
using Back.Ctac.Transversal.Functions;
using MediatR;

namespace Back.Ctac.Query.Nota.Recuperacion;

public class NotaEstudianteHandler : IRequestHandler<NotaEstudianteQuery, IEnumerable<NotaEstudianteResponse>>
{
    private readonly IQueryUnitOfWork _uow;
    protected readonly IMapper _mapper;

    public NotaEstudianteHandler(IQueryUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotaEstudianteResponse>> Handle(NotaEstudianteQuery request, CancellationToken cancellationToken)
    {

        return await GetNotasRecuperacion(request.entity);


    }

    private async Task<IEnumerable<NotaEstudianteResponse>> GetNotasRecuperacion(NotaEstudianteRequest entity)
    {
        var result = await _uow.NotaEstudianteRepository.GetNotas(entity);

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