namespace Basket.Basket.EventHandlers;

public class ProductPriceChangedIntegrationEventHandler
              (ISender sender, ILogger<ProductPriceChangedIntegrationEventHandler> logger)
             : IConsumer<ProductPriceChangedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<ProductPriceChangedIntegrationEvent> context)
    {
        logger.LogInformation($"Integration Event handled: {context.Message.GetType().Name}");

        var command = new UpdateItemPriceInBasketCommand(context.Message.ProductId, context.Message.Price);

        var result = await sender.Send(command);

        if (!result.IsSuccess)
            logger.LogError("Error when trying to update item price in basket. with Id {ProductId}", context.Message.ProductId);
        else
            logger.LogInformation("Price for product with id {ProductId} has been updated", context.Message.ProductId);
    }
}
