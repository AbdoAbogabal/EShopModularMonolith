
namespace Catelog.Products.EventHandlers;

public class ProcudtCreatedEventHandler(ILogger<ProcudtCreatedEventHandler> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain Event Handled {notification.GetType().Name}");

        return Task.CompletedTask;
    }
}
