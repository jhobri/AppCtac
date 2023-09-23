using Back.Ctac.Api.Extensions;
using System.Diagnostics;
using System.Text.Json;

namespace Back.Ctac.Api.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : MediatR.IPipelineBehavior<TRequest, TResponse>
    where TRequest : MediatR.IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, MediatR.RequestHandlerDelegate<TResponse> next)
    {
        string requestName = typeof(TRequest).Name;
        string unqiueId = Guid.NewGuid().ToString();
        string requestJson = JsonSerializer.Serialize(request);
        string commandName = request.GetGenericTypeName();

        _logger.LogInformation($"Begin Request Id:{unqiueId}, request name:{requestName},  Handling command: {commandName},  request json:{requestJson}");
        var timer = new Stopwatch();
        timer.Start();
        var response = await next();
        timer.Stop();
        _logger.LogInformation($"End Request Id:{unqiueId}, request name:{requestName},handled - response: {response}, total request time:{timer.ElapsedMilliseconds}ms");
        return response;
    }
}