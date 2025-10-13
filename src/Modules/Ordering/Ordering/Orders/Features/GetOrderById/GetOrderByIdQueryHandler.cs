namespace Ordering.Orders.Features.GetOrderById;

public record GetOrderByIdResult(OrderDto Order);

public class GetOrderByIdQueryHandler
            (IOrderRepository orderRepository)
    : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderById(request.OrderId, cancellationToken);

        var orderDto = order.Adapt<OrderDto>();

        return new GetOrderByIdResult(orderDto);
    }
}
