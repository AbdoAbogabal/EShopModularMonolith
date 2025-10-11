namespace Basket.Data.Processors;

public class OutboxProcessor
    (IServiceProvider serviceProvider, IBus bus, ILogger<OutboxProcessor> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<BasketDbContext>();

                var processedMessages = await dbContext.OutboxMessages.Where(e => e.ProcessdeOn == null)
                                                                      .ToListAsync(stoppingToken);

                foreach (var processedMessage in processedMessages)
                {
                    var eventType = Type.GetType(processedMessage.Type);
                    if (eventType is null)
                    {
                        logger.LogError("Could not resolve type: {Type}", processedMessage.Type);
                        continue;
                    }

                    var eventMessage = JsonSerializer.Deserialize(processedMessage.Content, eventType);
                    if (eventMessage is null)
                    {
                        logger.LogError("Could not Deserialize message: {Content}", processedMessage.Content);
                        continue;
                    }

                    await bus.Publish(eventMessage, stoppingToken);

                    processedMessage.ProcessdeOn = DateTime.UtcNow;
                    logger.LogInformation("Successfuly proccessed outbox message with Id: {Id}", processedMessage.Id);
                }

                await dbContext.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error happen while processing outbox message");
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
