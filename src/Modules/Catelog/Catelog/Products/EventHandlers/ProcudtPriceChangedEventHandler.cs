namespace Catelog.Products.EventHandlers;

public class ProcudtPriceChangedEventHandler(ILogger<ProcudtPriceChangedEventHandler> logger)
    : INotificationHandler<ProductPriceChangedEvent>
{
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain Event Handled {notification.GetType().Name}");

        return Task.CompletedTask;
    }
}
