using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Api.Extensions
{
    public static class CustomExtensionApiController
    {
        public static IServiceCollection AddCustomApiController(this IServiceCollection services)
        {
            services.PostConfigure((Action<ApiBehaviorOptions>)(options =>
            {
                var defaultFactory = options.InvalidModelStateResponseFactory;
                options.InvalidModelStateResponseFactory = context =>
                {
                    AllowSynchronousIO(context.HttpContext);

                    ////////////////////// CURRENT ModelValidation Filter /////////////
                    var modelState = context.ModelState;
                    var prop = modelState.Keys.ToList().FirstOrDefault();
                    var key = prop.Replace("$.", "");

                    var statusResponse = CustomResponse(context, key);
                    ////////////////////// CURRENT ModelValidation Filter /////////////
                    var result = defaultFactory(context);

                    var bad = result as BadRequestObjectResult;
                    if (bad?.Value is ValidationProblemDetails problem)
                        LogInvalidModelState(context, problem);

                    return new BadRequestObjectResult(statusResponse);
                };
            }));
            return services;
        }

        private static void AllowSynchronousIO(HttpContext httpContext)
        {
            IHttpBodyControlFeature? maybeSyncIoFeature = httpContext.Features.Get<IHttpBodyControlFeature>();
            if (maybeSyncIoFeature is IHttpBodyControlFeature syncIoFeature)
                syncIoFeature.AllowSynchronousIO = true;
        }

        private static StatusResponse<IEnumerable<bool>> CustomResponse(ActionContext context, string key)
        {
            var validations = CustomMessageResponse(context, key);
            return new StatusResponse<IEnumerable<bool>>()
            {
                Code = "40001",
                Message = "Solicitud con inconsistencias.",
                Success = false,
                Data = new List<bool>(),
                Validations = validations
            };
        }

        private static List<MessageStatusResponse> CustomMessageResponse(ActionContext context, string key)
        {
            var validations = new List<MessageStatusResponse>();
            var index = 0;
            foreach (var model in context.ModelState.Values)
            {
                var errors = model.Errors;
                if (errors.Count > 0)
                {
                    var error = errors.FirstOrDefault();
                    var errorMessage =
                             error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int16") ? "El parámetro " + key + " contiene valores no permitidos (A001)."
                        : error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Date") ? $"El parámetro {key}  contiene valores no permitidos, el valor del parámetro no cumple con el formato aaaa-mm-dd."
                        : error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Boolean") ? $"El parámetro {key} contiene valores no permitidos (A002)."
                        : error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.String") ? $"El parámetro {key} contiene valores no permitidos (A003)"
                        : error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int32") ? $"El parámetro {key} contiene valores no permitidos (A004)"
                        : error.ErrorMessage.Contains("The JSON value could not be converted") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage.Contains("The JSON object contains a trailing comma") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage.Contains("is an invalid start of a") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage;

                    validations.Add(new MessageStatusResponse(errorMessage, index.ToString()));
                    index++;
                }
            }
            return validations;
        }

        private static void LogInvalidModelState(ActionContext actionContext, ValidationProblemDetails error)
        {
            var errorJson = System.Text.Json.JsonSerializer.Serialize(error);

            var reqBody = actionContext.HttpContext.Request.Body;
            if (reqBody.CanSeek) reqBody.Position = 0;
            var sr = new StreamReader(reqBody);
            string body = sr.ReadToEnd();

            actionContext.HttpContext
                .RequestServices.GetRequiredService<ILoggerFactory>()
                .CreateLogger(nameof(ApiBehaviorOptions.InvalidModelStateResponseFactory))
                .LogWarning("Invalid model state. Responded: '{ValidationProblemDetails}'. Received: '{Request}'", errorJson, body);
        }
    }
}