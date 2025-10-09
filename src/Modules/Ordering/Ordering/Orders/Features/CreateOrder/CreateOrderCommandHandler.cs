namespace Ordering.Orders.Features.CreateOrder;

public record CreateOrderResult(Guid OrderId);

public class CreateOrderCommandHandler
            (OrderingDbContext context)
            : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(command.Order);

        context.Orders.Add(order);

        await context.SaveChangesAsync();

        return new CreateOrderResult(order.Id);
    }

    private Order CreateNewOrder(OrderDto orderDto)
    {
        var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName, orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country, orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);
        var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);

        var payment = Payment.Of(orderDto.Payment.CVV, orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.PaymentType);

        var newOrder = Order.Create(Guid.NewGuid(),
                                 orderDto.CustomerId,
                                 $"{orderDto.OrderName}_{new Random().Next()}",
                                 shippingAddress,
                                 billingAddress,
                                 payment);

        foreach (var item in orderDto.Items)
            newOrder.AddProduct(item.ProductId, item.Quantity, item.Price);


        return newOrder;
    }
}
