using Microsoft.IO;
using Minedu.Fw.General.Response.Status;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Back.Ctac.Api.Middleware
{
    public class HttpCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private string bodyParam = "";
        private List<MessageStatusResponse> _validationLst { get; set; }

        public HttpCustomMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;


            var qs = request.QueryString.ToString();
            JsonDocument jObject = null;
            var originalBodyStream = httpContext.Response.Body;
            var responseFail = new StatusResponse<string>();
            bool isQuery = true;
            var isBody = await IsFromBodyRequest(httpContext);
            _validationLst = new List<MessageStatusResponse>();

            if (httpContext.Request.Method == "GET" && !isBody.Success)
            {
                var isGet = IsFromQueryRequest(httpContext);
                if (!isGet.Success)
                {
                    responseFail.Message = isGet.Message;
                    responseFail.Code = isGet.Code;
                    isQuery = false;
                }
            }
            else if (httpContext.Request.Method != "GET" && !isBody.Success)//Cuando Body es null
            {
                _validationLst.Add(new MessageStatusResponse("La petición HTTP contiene esquema Json no válido.", "003"));
                responseFail.Message = "Solicitud con inconsistencias.";
                responseFail.Code = "40001";
                isQuery = false;
            }
            else if (!httpContext.Request.HasFormContentType)
            {
                var parameter = IsOKFromBodyParameter(isBody.Data);
                if (isBody.Data != string.Empty && !parameter.Success)
                {
                    responseFail.Message = parameter.Message;
                    responseFail.Code = parameter.Code;
                    isQuery = false;
                }
            }

            if (isQuery)
            {
                switch (request.Method)
                {
                    case "GET":
                        var cadena = request.QueryString.Value;
                        cadena = cadena.Replace("+", "%2B");
                        request.QueryString = new QueryString(cadena);
                        break;

                    case "POST":
                    case "PUT":
                    case "PATCH":
                    case "DELETE":
                        if (bodyParam != null && !httpContext.Request.HasFormContentType)
                        {
                            var requestContent = new StringContent(bodyParam, Encoding.UTF8);
                            request.Body = await requestContent.ReadAsStreamAsync();
                        }
                        break;

                    default:
                        break;
                }
                await using var responseBody = _recyclableMemoryStreamManager.GetStream();
                httpContext.Response.Body = responseBody;

                long length = 0;
                httpContext.Response.OnStarting(() =>
                {
                    httpContext.Response.Headers.ContentLength = length;
                    return Task.CompletedTask;
                });

                await _next(httpContext);

                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

                var contentType = httpContext.Response.ContentType?.ToLower();
                contentType = contentType?.Split(';', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

                // Respuesta por mensajes:
                //if (jObject == null)
                //{
                //    jObject = new JsonDocument();
                //}
                var _setCustomBodyparam = false;
                var _customBodyparam = "";
                var _setContentType = false;
                var _contentType = "";

                if (contentType == null)
                {
                    var mensaje = "";
                    switch (httpContext.Response.StatusCode)
                    {
                        case 404:
                            mensaje = "La petición HTTP no ha encontrado el recurso solicitado.";
                            _validationLst = new List<MessageStatusResponse>();
                            _validationLst.Add(new MessageStatusResponse("La petición HTTP debe tener una ruta válida.", "002"));
                            break;

                        default:
                            mensaje = "Error en la petición HTTP.";
                            _validationLst = new List<MessageStatusResponse>();
                            _validationLst.Add(new MessageStatusResponse("La petición HTTP debe tener una ruta válida.", "002"));
                            break;
                    }

                    var response = new StatusResponse<string>();
                    response.Code = "40402";
                    response.Success = false;
                    response.Data = null;
                    response.Message = mensaje;
                    response.Validations = _validationLst;
                    _setCustomBodyparam = true;
                    _setContentType = true;
                    _customBodyparam = JsonSerializer.Serialize(response);
                    _contentType = "application/json";
                }

                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                if (_setContentType) httpContext.Response.ContentType = _contentType;
                if (_setCustomBodyparam) bodyParam = _customBodyparam;
                else { bodyParam = await new StreamReader(httpContext.Response.Body).ReadToEndAsync(); }

                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
                await httpContext.Response.WriteAsync(bodyParam);
                length = httpContext.Response.Body.Length;
                httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBody.CopyToAsync(originalBodyStream);
            }
            else
            {
                if (_validationLst != null)
                {
                    foreach (var item in _validationLst)
                    {
                        responseFail.Validations.Add(item);
                    }
                }

                httpContext.Response.StatusCode = responseFail.Code.Contains("404") ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.BadRequest;
                httpContext.Response.ContentType = "application/json";
                bodyParam = JsonSerializer.Serialize(responseFail);

                await httpContext.Response.WriteAsync(bodyParam, Encoding.UTF8);
            }
        }

        private async Task<StatusResponse<string>> IsFromBodyRequest(HttpContext http)
        {
            var response = new StatusResponse<string>();
            response.Success = true;

            if (http.Request.HasFormContentType)
            {
                return response;
            }

            using (StreamReader reader = new StreamReader(http.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyParam = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(bodyParam)) { response.Success = false; }
                else { response.Data = bodyParam; }
            }
            return response;
        }

        private StatusResponse IsOKFromBodyParameter(string param)
        {
            var isJson = IsValidJson(param, "body");
            if (!isJson.Success) return new StatusResponse { Success = isJson.Success, Code = "40001", Message = "Solicitud con inconsistencias." };

            var json = JsonDocument.Parse(param);
            return new StatusResponse() { Success = true };
        }

        private StatusResponse IsValidJson(string request, string tipo)
        {
            request = request.Trim();
            var response = new StatusResponse();
            response.Success = true;

            if (request == null)
            {
                response.Success = false;
                _validationLst.Add(new MessageStatusResponse("La petición HTTP contiene esquema Json no válido.", "004"));
                return response;
            }
            try
            {
                JsonDocument.Parse(request);
                return response;
            }
            catch (JsonException ex)
            {
                response.Success = false;
                _validationLst.Add(new MessageStatusResponse("La petición HTTP contiene esquema Json no válido.", "003"));
                return response;
            }
        }

        private StatusResponse<string> IsFromQueryRequest(HttpContext http)
        {
            if (!IsValidStartsWithSegmentsError(http))
                return new StatusResponse<string> { Code = "40402", Message = "Solicitud no encuentra el recurso solicitado.", Success = false };

            if (!IsValidStartsWithSegments(http))
                return new StatusResponse<string> { Code = "40402", Message = "Solicitud no encuentra el recurso solicitado.", Success = false };

            return new StatusResponse<string>() { Success = true, Data = null };
        }

        private bool IsValidStartsWithSegments(HttpContext http)
        {
            var request = http.Request;
            bool isOk = true;

            if (request.Path.StartsWithSegments(new PathString("/api"))) return isOk;
            if (request.Path.StartsWithSegments(new PathString("/docs/specification"))) return isOk;
            if (request.Path.StartsWithSegments(new PathString("/swagger"))) return isOk;

            isOk = false;
            _validationLst.Add(new MessageStatusResponse("La petición HTTP debe iniciar con /api.", "001"));

            return isOk;
        }

        private bool IsValidStartsWithSegmentsError(HttpContext http)
        {
            var request = http.Request;
            bool isOk = true;
            if (!request.Path.StartsWithSegments(new PathString("/api/error"))) return isOk;
            isOk = false;
            _validationLst.Add(new MessageStatusResponse("La petición HTTP debe tener una ruta válida.", "002"));
            return isOk;
        }
    }
}