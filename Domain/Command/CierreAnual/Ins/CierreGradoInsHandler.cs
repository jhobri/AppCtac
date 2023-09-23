using AutoMapper;
using Back.Ctac.Rest.Service.Fruta;
using Back.Ctac.Rest.Service.Proxy.Model.Fruta;
using Back.Ctac.Transversal.Constants;
using Back.Ctac.Transversal.Enum;
using Back.Ctac.Transversal.Extension;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;
using Minedu.Fw.General.Models.Configurations;
using Minedu.Fw.General.Response.Status;

using Minedu.Siagie.Events;
using System.Net;

namespace Back.Ctac.Command.CierreAnual.Ins;

public class CierreGradoInsHandler : IRequestHandler<CierreGradoInsCommand, StatusResponse<int>>
{
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;
    protected readonly IFrutaApiGateway _appProceso;
   
    private readonly IBus _bus;
    private readonly QueueConfiguration _queue;

    public CierreGradoInsHandler(
        IMapper mapper
        , IMediator mediator

        , IBus bus
        , IOptions<QueueConfiguration> queue
        , IFrutaApiGateway appProceso
        )
    {
        _mapper = mapper;
        _mediator = mediator;
        _bus = bus;
        _queue = queue.Value;  
        _appProceso = appProceso;
       
    }

    public async Task<StatusResponse<int>> Handle(CierreGradoInsCommand request, CancellationToken cancellationToken)
    {
        var response = new StatusResponse<int>();

        /*
        var provider = new GeneralProvider(_mediator, _appAdministracion, _appEvaluacionGeneral);

        #region VALIDAR IE-EN SIAGIE-20



        var ie_service = await provider.GetIe(request.entity.CodigoModular, request.entity.Anexo, request.entity.Anio);
        //ProcesarGrado.ValidateIeIns(ie_service);

        #endregion VALIDAR IE-EN SIAGIE-20

        #region VALIDAR GRADOS GENERALES
        var gradosRest = await provider.GetGrados(request.entity.CodigoModular, request.entity.Anexo, request.entity.Anio);
        #endregion


        #region VALIDAR GRADO-RECUPERACION
        var grados = await _mediator.Send(new GradosQuery(new GradoRequest() { CodigoModular = request.entity.CodigoModular, Anexo = request.entity.Anexo, Anio = request.entity.Anio }));
        #endregion

        var grados_request = request.entity.Grados.ToList();

        foreach (var g in grados_request)
        {
            if (!grados.Any(x => x.GradoEvaluacionId == g.Id))
            {
                g.Mensaje = $"El grado {g.Id} no forma parte de recuperación.";
                continue;
            }

            var grado = grados.First(x => x.GradoEvaluacionId == g.Id);
            var gradoGeneral = gradosRest.FirstOrDefault(x => x.Id == grado.GradoId);
            g.Codigo = grado.GradoId;
            g.Nombre = gradoGeneral.Nombre;


            if (grado.EstadoProcesamiento == EstadoProceso.Habilitado) { g.EsValido = true; continue; }

            g.Mensaje = grado.EstadoProcesamiento switch
            {

                EstadoProceso.Habilitado => $"El grado {gradoGeneral?.Nombre} se encuentra habilitado",
                EstadoProceso.CierreAnual => $"El grado {gradoGeneral?.Nombre} se encuentra con cierre anual",
                _ => $"El grado {gradoGeneral?.Nombre} se encuentra con estado no identificado",
            };

        }


        var gradosValidos = grados_request.Where(x => x.EsValido).ToList();
        if (!gradosValidos.Any())
        {
            response.Validations = grados_request.Where(x => !x.EsValido).Select(x => { return new MessageStatusResponse(x.Mensaje); }).ToList();
            return response;
        }


        int cantidadEncolado = 0;
        List<MessageStatusResponse> Validations = new List<MessageStatusResponse>(); ;

        foreach (var item in gradosValidos)
        {

            #region VALIDAR PROCESO-REGISTRO-SECCION

            var oValidateProcesoPendiente = (await _appProceso.ValidarProcesoPendiente(new GetValidacionProcesoRequest()
            {
                CodigoModular = request.entity.CodigoModular,
                anexo = request.entity.Anexo,
                anio = request.entity.Anio,
                nivelId = ie_service.NivelId,
                periodoId = "A1",
                faseId = Fase.RECUPERACION,
                gradoId = item.Codigo,
                //seccionId = item.Codigo,
                TipoProcesoId = (int)EnumTipoProceso.Recuperacion,
                usuario = string.IsNullOrEmpty(request.entity.Usuario) ? "ADMIN" : request.entity.Usuario
            })).GetResponse<bool>();


            if (oValidateProcesoPendiente.Validations.Any())
            {
                Validations.AddRange(oValidateProcesoPendiente.Validations.Select(x => { return new MessageStatusResponse(x.Message); }));
                continue;
            }


            if (oValidateProcesoPendiente.Data)
            {
                Validations.Add(new MessageStatusResponse($"Existe un proceso con los mismos datos que no ha concluido. Tendrá que esperar a que concluya el proceso anterior, para generar un nuevo proceso para el grado {item?.Nombre}"));
                continue;
            }

            #endregion VALIDAR PROCESO-REGISTRO-SECCION

            #region REGISTRAR PROCESO

            var oProceso = await RegistrarProceso(new PostProcesoRequest()
            {
                codigoModular = request.entity.CodigoModular,
                anexo = request.entity.Anexo,
                anio = request.entity.Anio,
                nivelId = ie_service.NivelId,
                disenioId = ie_service.DisenioId,
                periodoId = "A1",
                faseId = Fase.RECUPERACION,
                gradoId = item.Codigo,
                //seccionId = item.Codigo,
                usuario = request.entity.Usuario
            });
            if (oProceso.Validations.Any())
            {
                Validations.AddRange(oProceso.Validations.Select(x => { return new MessageStatusResponse($"Error en registrar proceso, para el grado {item!.Nombre} - {x.Message}"); }));
                continue;
            }
            if (!oProceso.Success)
            {
                Validations.Add(new MessageStatusResponse($"Error en registrar proceso, para el grado {item!.Nombre}."));
                continue;
            }


            #endregion REGISTRAR PROCESO

            var eventMessage = new CierreAnualRecuperacionRecepcionEvent()//CierreAnualRecuperacionRecepcionEvent()
            {
                ProcesoId = oProceso.Data.Id,
                CodigoModular = request.entity.CodigoModular,
                Anexo = request.entity.Anexo,
                Anio = request.entity.Anio,
                //PeriodoId = "A1",
                GradoId = item.Id,
                GradoNombre = item!.Nombre,
                GradoEquivalenciaId = item.Codigo,
                //ModalidadId = ie_service.ModalidadId,
                DisenioId = ie_service.DisenioId,
                NivelId = ie_service.NivelId,
                Usuario = request.entity.Usuario,
                //ConTallerSeleccionable = ie_service.ConTallerSeleccionable,
                FaseId = Fase.RECUPERACION,
                RolId = request.entity.RolId,
                //TipoEvaluacion = TipoEvaluacion.RECUPERACION
            };

            var queuehost = _queue.HostName;
            var queueNname = _queue.EndpointEvaluacionRecuperacionCierreAnualValidacion;
            Uri uri = new Uri(string.Concat(queuehost, "/", queueNname));
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(eventMessage);
            cantidadEncolado++;
        }

        */

        var trx = 1;
        response.Data = trx;
       
        return response;
    }


    /*
    private async Task<StatusResponse<ProcesoUniqueResponse>> RegistrarProceso(PostProcesoRequest entity)
    {


        entity.tipoProcesoId = (int)EnumTipoProceso.Recuperacion;
        entity.tipoSubProcesoId = (int)EnumSubTipoProcesoRecuperacion.ProcesoCierreAnual;
        entity.etapa = new FrutaRequest()
        {
            id = (short)EnumEtapaProceso.Recepcion,
            nombreServidor = Dns.GetHostName()
        };
        var oProceso = (await _appProceso.RegistrarProceso(entity)).GetResponse<ProcesoUniqueResponse>();
        return oProceso;


    }
    */

}