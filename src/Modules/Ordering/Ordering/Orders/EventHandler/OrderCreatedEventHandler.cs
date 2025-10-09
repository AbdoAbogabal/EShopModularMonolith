namespace Ordering.Orders.EventHandler;

public class OrderCreatedEventHandler
            (ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("OrderCreatedEvent has beed handled");

        return Task.CompletedTask;
    }
}
