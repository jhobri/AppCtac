using MediatR;
using Microsoft.Extensions.Options;
using Minedu.Siagie.Evaluacion.Periodo.Dto.Grado;
using Minedu.Siagie.Evaluacion.Periodo.Dto.PeriodoEvaluacion;
using Minedu.Siagie.Evaluacion.Periodo.Dto.PeriodoEvaluacionExcel;
using Minedu.Siagie.Evaluacion.Periodo.Dto.PeriodoPromocional;
using Minedu.Siagie.Evaluacion.Periodo.Dto.Seccion;
using Minedu.Siagie.Evaluacion.Periodo.Help.Constants;
using Minedu.Siagie.Evaluacion.Periodo.Help.Extension;
using Minedu.Siagie.Evaluacion.Periodo.Help.Functions;
using Minedu.Siagie.Rest.Service.Proxy.SiagieMsa.MsaIeAdministracion;
using Minedu.Siagie.Rest.Service.SiagieMsa;
using Newtonsoft.Json;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        protected readonly IMediator _mediator;
        protected readonly ISiagieMsaEvaluacionPeriodoApiGateway _evaluacionPeriodoApi;
        protected readonly ISiagieMsaIeAdministracionApiGateway _ieAdministracionApi;
        private readonly MigradorConfiguration _migrador;

        public Worker(ILogger<Worker> logger, IMediator mediator, ISiagieMsaEvaluacionPeriodoApiGateway evaluacionPeriodoApi, IOptions<MigradorConfiguration> migrador, ISiagieMsaIeAdministracionApiGateway ieAdministracionApi)
        {
            _logger = logger;
            _mediator = mediator;
            _evaluacionPeriodoApi = evaluacionPeriodoApi;
            _migrador = migrador.Value;
            _ieAdministracionApi = ieAdministracionApi;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);

            var cltToken = new CancellationToken();
            var iesMasivas = new Institucion();

            using (StreamReader r = new StreamReader("InstitucionesEducativas.json"))
            {
                string json = r.ReadToEnd();
                iesMasivas = JsonConvert.DeserializeObject<Institucion>(json);
            }
            _logger.LogInformation($"INSTITUCIONES EDUCATIVAS TOTAL {iesMasivas.instituciones.Count()}");

            foreach (var ieJson in iesMasivas.instituciones)
            {
                var codigoModular = ieJson.CodigoModular;
                var anexo = ieJson.Anexo;
                short anio = ieJson.Anio;
                var periodoCode = "";//ieJson.Periodo;
                int periodoId = 0;
                var usuario = _migrador.Usuario;
                var rolId = _migrador.RolId;

                var periodoPromocionalAlias = ieJson.PeriodoPromocionalAlias;
                var _periodoPromocionalId = 0;
                var _periodoPromocionalCode = 0;

                var _PeriodoEvaluacionAlias = ieJson.PeriodoEvaluacionAlias;

                _logger.LogInformation($"CONFIGURANDO {codigoModular}-{anexo} PARA EL ANIO {anio}");
                _logger.LogInformation($"CONSULTANDO PERIODOS...");

                // datos de la ie
                var getIe = await _ieAdministracionApi.GetInstitucionEducativa(new GetInstitucionEducativaAnioRestRequest()
                {
                    CodigoModular = codigoModular,
                    Anexo = anexo,
                    Anio = anio
                });

                var getIeData = HelperType<GetInstitucionEducativaAnioRestResponse>.ConvertFromDynamicV2(getIe);
                if (getIeData.Success)
                {
                    if (getIeData.Data.ModalidadId == ConstanteModalidad.EBA)
                    {
                        // periodos promocionales de la ie
                        var getPeriodosPromocionales = await _evaluacionPeriodoApi.GetEvaluacionPeriodoPromocionalLista(new GetPeriodoPromocionalPorAnioLstRequest()
                        {
                            CodigoModular = codigoModular,
                            Anexo = anexo,
                            Anio = anio
                        });

                        var getPeriodosPromocionalesData = HelperType<IEnumerable<GetPeriodoPromocionalPorAnioLstResponse>>.ConvertFromDynamicV2(getPeriodosPromocionales);
                        if (getPeriodosPromocionalesData.Success)
                        {
                            var _periodoPromocional = FuncionesComunes.PeriodoPromocionalAliasToDb(periodoPromocionalAlias);

                            foreach (var pp in getPeriodosPromocionalesData.Data)
                            {
                                var _periodoPromocionalOk = FuncionesComunes.EsMismoPeriodoPromocional(pp.Nombre, _periodoPromocional);
                                if (_periodoPromocionalOk)
                                {
                                    _periodoPromocionalId = pp.Id;
                                    _periodoPromocionalCode = pp.Code;
                                    break;
                                }
                            }

                            //grados eba
                            var getGradosEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoGradosLista(new GetGradoPeriodoPromocionalLstRequest()
                            {
                                CodigoModular = codigoModular,
                                Anexo = anexo,
                                Anio = anio,
                                PeriodoId = _periodoPromocionalId
                            });
                            var getGradosEvaluacionData = HelperType<IEnumerable<GetGradoPeriodoPromocionalLstResponse>>.ConvertFromDynamicV2(getGradosEvaluacion);
                            if (getGradosEvaluacionData.Success)
                            {
                                foreach (var grados in getGradosEvaluacionData.Data)
                                {
                                    // secciones eba

                                    var getSeccionesEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoSeccionesLista(new GetSeccionPeriodoPromocionalLstRequest()
                                    {
                                        CodigoModular = codigoModular,
                                        Anexo = anexo,
                                        Anio = anio,
                                        PeriodoId = _periodoPromocionalId,
                                        GradoId = grados.Id
                                    });
                                    var getSeccionesEvaluacionData = HelperType<IEnumerable<GetSeccionPeriodoPromocionalLstResponse>>.ConvertFromDynamicV2(getSeccionesEvaluacion);
                                    if (getSeccionesEvaluacionData.Success)
                                    {
                                        foreach (var secciones in getSeccionesEvaluacionData.Data)
                                        {
                                            // periodos de evaluacion
                                            var getSeccionesPeriodosEvaluacionEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionSeccionesPeriodoEvaluacionLista(new GetPeriodoPromocionalPeriodoEvaluacionLstRequest()
                                            {
                                                CodigoModular = codigoModular,
                                                Anexo = anexo,
                                                Anio = anio,
                                                PeriodoId = _periodoPromocionalId,
                                                GradoId = grados.Id,
                                                SeccionId = secciones.Id
                                            });

                                            var getSeccionesPeriodosEvaluacionEvaluacionData = HelperType<IEnumerable<GetPeriodoPromocionalPeriodoEvaluacionLstResponse>>.ConvertFromDynamicV2(getSeccionesPeriodosEvaluacionEvaluacion);
                                            if (getSeccionesPeriodosEvaluacionEvaluacionData.Success)
                                            {
                                                foreach (var periodoEvaluacionEba in getSeccionesPeriodosEvaluacionEvaluacionData.Data)
                                                {
                                                    var castPeriodo = FuncionesComunes.PeriodoEvaluacionAliasToDb(periodoEvaluacionEba.Code, _PeriodoEvaluacionAlias);
                                                    var xx = FuncionesComunes.EsMismoPeriodo(periodoEvaluacionEba.Code, castPeriodo /*periodoCode*/);
                                                    if (xx)
                                                    {
                                                        periodoCode = periodoEvaluacionEba.Code;
                                                        periodoId = periodoEvaluacionEba.Id;

                                                        break;
                                                    }
                                                }
                                                //generar data

                                                var getNotasPorSeccion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoExcel(new GetExcelEvaluacionPeriodoNotaRequestDto()
                                                {
                                                    CodigoModular = codigoModular,
                                                    Anexo = anexo,
                                                    Anio = anio,
                                                    PeriodoPromocionalId = _periodoPromocionalId,
                                                    PeriodoId = periodoCode,
                                                    GradoId = grados.Id,
                                                    SeccionId = secciones.Id.ToString(),
                                                    RolId = rolId,
                                                    Usuario = usuario
                                                });

                                                var getNotasPorSeccionData = HelperType<GetExcelEvaluacionPeriodoNotaTestResponseDto>.ConvertFromDynamicV2(getNotasPorSeccion);
                                                if (getNotasPorSeccionData.Success)
                                                {
                                                    var PostNotasPorSeccion = await _evaluacionPeriodoApi.PostEvaluacionPeriodoExcel(new PostExcelEvaluacionPeriodoNotaTestRequestDto()
                                                    {
                                                        CodigoModular = codigoModular,
                                                        Anexo = anexo,
                                                        Anio = anio,
                                                        PeriodoPromocionalId = _periodoPromocionalId,
                                                        PeriodoId = periodoCode,
                                                        GradoId = grados.Id,
                                                        SeccionId = secciones.Id.ToString(),
                                                        RolId = rolId,
                                                        Usuario = usuario,
                                                        lstArea = getNotasPorSeccionData.Data.areas
                                                    });

                                                    var PostNotasPorSeccionData = HelperType<string>.ConvertFromDynamicV2(PostNotasPorSeccion);

                                                    if (PostNotasPorSeccionData.Success)
                                                    {
                                                        _logger.LogInformation($"SECCION REGISTRADA: {periodoCode}-{periodoId}->{grados.Nombre}->{secciones.Id}");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var getPeriodosEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionLista(new GetEvaluacionPeriodoEvaluacionLstRequest()
                        {
                            CodigoModular = codigoModular,
                            Anexo = anexo,
                            Anio = anio,
                            Usuario = usuario
                        });
                        var getPeriodosEvaluacionData = HelperType<IEnumerable<GetEvaluacionPeriodoEvaluacionLstResponse>>.ConvertFromDynamicV2(getPeriodosEvaluacion);
                        if (getPeriodosEvaluacionData.Success)
                        {
                            _logger.LogInformation($"PERIODOS.. OK");
                            foreach (var item in getPeriodosEvaluacionData.Data)
                            {
                                _logger.LogInformation($"PERIODO: {item.Id}-{item.Code}-{item.Nombre}");
                                //var xx = FuncionesComunes.EsPrimerPeriodo(item.Code);

                                var castPeriodo = FuncionesComunes.PeriodoEvaluacionAliasToDb(item.Code, _PeriodoEvaluacionAlias);

                                var xx = FuncionesComunes.EsMismoPeriodo(item.Code, castPeriodo /*periodoCode*/);
                                if (xx)
                                {
                                    periodoCode = item.Code;
                                    periodoId = item.Id;
                                    _logger.LogInformation($"PERIODO SELECCIONADO: {item.Id}-{item.Code}-{item.Nombre}");
                                    break;
                                }
                            }
                            _logger.LogInformation($"CONSULTANDO GRADOS...");
                            var getGradosEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionGradoListaLista(new GetPeriodoEvaluacionGradoLstRequest()
                            {
                                CodigoModular = codigoModular,
                                Anexo = anexo,
                                Anio = anio,
                                Usuario = usuario,
                                PeriodoId = periodoId
                            });

                            var getGradosEvaluacionData = HelperType<IEnumerable<GetPeriodoEvaluacionGradoLstResponse>>.ConvertFromDynamicV2(getGradosEvaluacion);

                            if (getGradosEvaluacionData.Success)
                            {
                                _logger.LogInformation($"GRADOS.. OK");
                                foreach (var grado in getGradosEvaluacionData.Data)
                                {
                                    _logger.LogInformation($"GRADO ACTUAL: {grado.Id}-{grado.Code}-{grado.Nombre}");
                                    _logger.LogInformation($"CONSULTANDO SECCIONES DEL GRADO: {grado.Id}-{grado.Code}-{grado.Nombre}");
                                    var getseccionesEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionSeccionLista(new GetPeriodoEvaluacionSeccionLstRequest()
                                    {
                                        CodigoModular = codigoModular,
                                        Anexo = anexo,
                                        Anio = anio,
                                        Usuario = usuario,
                                        PeriodoId = periodoId,
                                        GradoId = grado.Id
                                    });

                                    var getseccionesEvaluacionData = HelperType<IEnumerable<GetPeriodoEvaluacionSeccionLstResponse>>.ConvertFromDynamicV2(getseccionesEvaluacion);
                                    if (getseccionesEvaluacionData.Success)
                                    {
                                        foreach (var seccion in getseccionesEvaluacionData.Data)
                                        {
                                            _logger.LogInformation($"SECCION ACTUAL: {seccion.Id}-{seccion.Code}-{seccion.Nombre}");
                                            _logger.LogInformation($"GENERANDO DATA PARA SECCION: {periodoCode}-{periodoId}->{grado.Nombre}-> {seccion.Id}-{seccion.Code}-{seccion.Nombre}");
                                            var getNotasPorSeccion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoExcel(new GetExcelEvaluacionPeriodoNotaRequestDto()
                                            {
                                                CodigoModular = codigoModular,
                                                Anexo = anexo,
                                                Anio = anio,
                                                PeriodoPromocionalId = 0,
                                                PeriodoId = periodoCode,
                                                GradoId = grado.Code,
                                                SeccionId = seccion.Code,
                                                RolId = rolId,
                                                Usuario = usuario
                                            });
                                            var getNotasPorSeccionData = HelperType<GetExcelEvaluacionPeriodoNotaTestResponseDto>.ConvertFromDynamicV2(getNotasPorSeccion);
                                            if (getNotasPorSeccionData.Success)
                                            {
                                                _logger.LogInformation($"REGISTRANDO DATA PARA SECCION: {periodoCode}-{periodoId}->{grado.Nombre}->{seccion.Id}-{seccion.Code}-{seccion.Nombre}");
                                                var PostNotasPorSeccion = await _evaluacionPeriodoApi.PostEvaluacionPeriodoExcel(new PostExcelEvaluacionPeriodoNotaTestRequestDto()
                                                {
                                                    CodigoModular = codigoModular,
                                                    Anexo = anexo,
                                                    Anio = anio,
                                                    PeriodoPromocionalId = 0,
                                                    PeriodoId = periodoCode,
                                                    GradoId = grado.Code,
                                                    SeccionId = seccion.Code,
                                                    RolId = rolId,
                                                    Usuario = usuario,
                                                    lstArea = getNotasPorSeccionData.Data.areas
                                                });

                                                var PostNotasPorSeccionData = HelperType<string>.ConvertFromDynamicV2(PostNotasPorSeccion);

                                                if (PostNotasPorSeccionData.Success)
                                                {
                                                    _logger.LogInformation($"SECCION REGISTRADA: {periodoCode}-{periodoId}->{grado.Nombre}->{seccion.Id}-{seccion.Code}-{seccion.Nombre}");
                                                }
                                            }
                                        }
                                        _logger.LogInformation($"TOTAL DE SECCIONES PROCESADOS {getseccionesEvaluacionData.Data.Count()} para el grado {grado.Nombre}");
                                    }
                                }
                                _logger.LogInformation($"TOTAL DE GRADOS PROCESADOS {getGradosEvaluacionData.Data.Count()}");
                            }
                            _logger.LogInformation($"FIN DE GRADOS PROCESADOS");
                        }
                        _logger.LogInformation($"FIN DE PERIODO PROCESADOS");
                    }
                }
            }

            #region old

            //foreach (var ieJson in iesMasivas.instituciones)
            //{
            //    var codigoModular = ieJson.CodigoModular;
            //    var anexo = ieJson.Anexo;
            //    short anio = ieJson.Anio;
            //    var periodoCode = ieJson.Periodo;
            //    int periodoId = 0;
            //    var usuario = _migrador.Usuario;
            //    var rolId = _migrador.RolId;
            //    _logger.LogInformation($"CONFIGURANDO {codigoModular}-{anexo} PARA EL ANIO {anio}");
            //    _logger.LogInformation($"CONSULTANDO PERIODOS...");

            //    var getPeriodosEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionLista(new GetEvaluacionPeriodoEvaluacionLstRequest()
            //    {
            //        CodigoModular = codigoModular,
            //        Anexo = anexo,
            //        Anio = anio,
            //        Usuario = usuario
            //    });
            //    var getPeriodosEvaluacionData = HelperType<IEnumerable<GetEvaluacionPeriodoEvaluacionLstResponse>>.ConvertFromDynamicV2(getPeriodosEvaluacion);
            //    if (getPeriodosEvaluacionData.Success)
            //    {
            //        _logger.LogInformation($"PERIODOS.. OK");
            //        foreach (var item in getPeriodosEvaluacionData.Data)
            //        {
            //            _logger.LogInformation($"PERIODO: {item.Id}-{item.Code}-{item.Nombre}");
            //            //var xx = FuncionesComunes.EsPrimerPeriodo(item.Code);
            //            var xx = FuncionesComunes.EsMismoPeriodo(item.Code, periodoCode);
            //            if (xx)
            //            {
            //                periodoCode = item.Code;
            //                periodoId = item.Id;
            //                _logger.LogInformation($"PERIODO SELECCIONADO: {item.Id}-{item.Code}-{item.Nombre}");
            //                break;
            //            }
            //        }
            //        _logger.LogInformation($"CONSULTANDO GRADOS...");
            //        var getGradosEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionGradoListaLista(new GetPeriodoEvaluacionGradoLstRequest()
            //        {
            //            CodigoModular = codigoModular,
            //            Anexo = anexo,
            //            Anio = anio,
            //            Usuario = usuario,
            //            PeriodoId = periodoId
            //        });

            //        var getGradosEvaluacionData = HelperType<IEnumerable<GetPeriodoEvaluacionGradoLstResponse>>.ConvertFromDynamicV2(getGradosEvaluacion);

            //        if (getGradosEvaluacionData.Success)
            //        {
            //            _logger.LogInformation($"GRADOS.. OK");
            //            foreach (var grado in getGradosEvaluacionData.Data)
            //            {
            //                _logger.LogInformation($"GRADO ACTUAL: {grado.Id}-{grado.Code}-{grado.Nombre}");
            //                _logger.LogInformation($"CONSULTANDO SECCIONES DEL GRADO: {grado.Id}-{grado.Code}-{grado.Nombre}");
            //                var getseccionesEvaluacion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoEvaluacionSeccionLista(new GetPeriodoEvaluacionSeccionLstRequest()
            //                {
            //                    CodigoModular = codigoModular,
            //                    Anexo = anexo,
            //                    Anio = anio,
            //                    Usuario = usuario,
            //                    PeriodoId = periodoId,
            //                    GradoId = grado.Id
            //                });

            //                var getseccionesEvaluacionData = HelperType<IEnumerable<GetPeriodoEvaluacionSeccionLstResponse>>.ConvertFromDynamicV2(getseccionesEvaluacion);
            //                if (getseccionesEvaluacionData.Success)
            //                {
            //                    foreach (var seccion in getseccionesEvaluacionData.Data)
            //                    {
            //                        _logger.LogInformation($"SECCION ACTUAL: {seccion.Id}-{seccion.Code}-{seccion.Nombre}");
            //                        _logger.LogInformation($"GENERANDO DATA PARA SECCION: {periodoCode}-{periodoId}->{grado.Nombre}-> {seccion.Id}-{seccion.Code}-{seccion.Nombre}");
            //                        var getNotasPorSeccion = await _evaluacionPeriodoApi.GetEvaluacionPeriodoExcel(new GetExcelEvaluacionPeriodoNotaRequestDto()
            //                        {
            //                            CodigoModular = codigoModular,
            //                            Anexo = anexo,
            //                            Anio = anio,
            //                            PeriodoPromocionalId = 0,
            //                            PeriodoId = periodoCode,
            //                            GradoId = grado.Code,
            //                            SeccionId = seccion.Code,
            //                            RolId = rolId,
            //                            Usuario = usuario
            //                        });
            //                        var getNotasPorSeccionData = HelperType<GetExcelEvaluacionPeriodoNotaTestResponseDto>.ConvertFromDynamicV2(getNotasPorSeccion);
            //                        if (getNotasPorSeccionData.Success)
            //                        {
            //                            _logger.LogInformation($"REGISTRANDO DATA PARA SECCION: {periodoCode}-{periodoId}->{grado.Nombre}->{seccion.Id}-{seccion.Code}-{seccion.Nombre}");
            //                            var PostNotasPorSeccion = await _evaluacionPeriodoApi.PostEvaluacionPeriodoExcel(new PostExcelEvaluacionPeriodoNotaTestRequestDto()
            //                            {
            //                                CodigoModular = codigoModular,
            //                                Anexo = anexo,
            //                                Anio = anio,
            //                                PeriodoPromocionalId = 0,
            //                                PeriodoId = periodoCode,
            //                                GradoId = grado.Code,
            //                                SeccionId = seccion.Code,
            //                                RolId = rolId,
            //                                Usuario = usuario,
            //                                lstArea = getNotasPorSeccionData.Data.areas
            //                            });

            //                            var PostNotasPorSeccionData = HelperType<string>.ConvertFromDynamicV2(PostNotasPorSeccion);

            //                            if (PostNotasPorSeccionData.Success)
            //                            {
            //                                _logger.LogInformation($"SECCION REGISTRADA: {periodoCode}-{periodoId}->{grado.Nombre}->{seccion.Id}-{seccion.Code}-{seccion.Nombre}");
            //                            }
            //                        }
            //                    }
            //                    _logger.LogInformation($"TOTAL DE SECCIONES PROCESADOS {getseccionesEvaluacionData.Data.Count()} para el grado {grado.Nombre}");
            //                }
            //            }
            //            _logger.LogInformation($"TOTAL DE GRADOS PROCESADOS {getGradosEvaluacionData.Data.Count()}");
            //        }
            //        _logger.LogInformation($"FIN DE GRADOS PROCESADOS");
            //    }
            //    _logger.LogInformation($"FIN DE PERIODO PROCESADOS");
            //}

            #endregion old
        }
    }
}