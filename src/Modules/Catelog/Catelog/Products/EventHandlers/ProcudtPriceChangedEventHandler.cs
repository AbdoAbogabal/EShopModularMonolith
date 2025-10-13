namespace Catelog.Products.EventHandlers;

public class ProcudtPriceChangedEventHandler(ILogger<ProcudtPriceChangedEventHandler> logger, IBus bus)
    : INotificationHandler<ProductPriceChangedEvent>
{
    public async Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Domain Event Handled {notification.GetType().Name}");

        var integrationEvent = new ProductPriceChangedIntegrationEvent
        {
            Name = notification.Product.Name,
            Price = notification.Product.Price,
            ProductId = notification.Product.Id,
            ImageFile = notification.Product.ImageFile,
            Category = notification.Product.Categories,
            Description = notification.Product.Description,
        };

        await bus.Publish(integrationEvent, cancellationToken);
    }
}
