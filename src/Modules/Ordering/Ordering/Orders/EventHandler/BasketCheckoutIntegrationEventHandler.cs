namespace Ordering.Orders.EventHandler;

public class BasketCheckoutIntegrationEventHandler
    (ISender sender, ILogger<BasketCheckoutIntegrationEventHandler> logger)
    : IConsumer<BasketCheckoutIntegrationEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutIntegrationEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEevnt}", context.Message.GetType().Name);

        var createOrderCommand = MapToCreateOrderCommand(context.Message);

        await sender.Send(createOrderCommand);
    }

    private static CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutIntegrationEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.Cvv, message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(orderId,
            message.CustomerId,
            message.UserName,
            addressDto,
            addressDto,
            paymentDto,
            new List<OrderItemDto>()
            {
                new (orderId, Guid.Parse("338e1fa4-ddf2-4ab8-a91f-02edc97da3d6"),2,500),
                new (orderId, Guid.Parse("708f261c-eee9-40b6-8639-25315d779ef9"),1,250),
            }
            );

        return new CreateOrderCommand(orderDto);
    }
}
