namespace Ordering.Orders.Features.GetOrderById;

public record GetOrderByIdResult(OrderDto Order);

public class GetOrderByIdQueryHandler
            (OrderingDbContext context)
    : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.AsNoTracking()
                                         .Include(e => e.Items)
                                         .SingleOrDefaultAsync(e => e.Id.Equals(request.OrderId), cancellationToken);

        if (order is null) throw new OrderNotFoundException(request.OrderId);

        var orderDto = order.Adapt<OrderDto>();

        return new GetOrderByIdResult(orderDto);
    }
}
