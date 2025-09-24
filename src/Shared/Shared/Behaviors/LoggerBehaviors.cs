namespace Shared.Behaviors;

public class LoggerBehaviors<TRequest, TResponse>(ILogger<LoggerBehaviors<TRequest, TResponse>> logger)
             : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"[START] Handle request={typeof(TRequest).Name} - response={typeof(TResponse).Name} - RequestDate={DateTime.UtcNow}");

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)
            logger.LogWarning($"[PERFORMANCE] The Request {typeof(TRequest).Name} took {timeTaken.Seconds} Seconds");

        logger.LogWarning($"[END] Request {typeof(TRequest).Name} Handled with response {typeof(TResponse).Name}");

        return response;
    }
}
