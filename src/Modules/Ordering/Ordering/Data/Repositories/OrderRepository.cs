namespace Ordering.Data.Repositories;

internal class OrderRepository(OrderingDbContext context)
               : IOrderRepository
{
    public async Task<Order> CreateOrder(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(command.Order);

        context.Orders.Add(order);

        await context.SaveChangesAsync(cancellationToken);

        return order;
    }

    public async Task<List<Order>> GetOrders(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var orders = await context.Orders.AsNoTracking()
                                         .Include(e => e.Items)
                                         .Skip(pageSize * pageNumber)
                                         .Take(pageSize)
                                         .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<int> GetCount(CancellationToken cancellationToken) =>
           await context.Orders.CountAsync(cancellationToken);

    public async Task<Order> GetOrderById(Guid id, CancellationToken cancellationToken)
    {
        var order = await context.Orders.AsNoTracking()
                                        .Include(e => e.Items)
                                        .SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken) ??
                                        throw new OrderNotFoundException(id);

        return order;
    }

    public async Task<bool> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FindAsync([id], cancellationToken) ??
                          throw new OrderNotFoundException(id);

        context.Orders.Remove(order);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static Order CreateNewOrder(OrderDto orderDto)
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
