namespace Ordering.Orders.Features.GetOrders;

public record GetOrderResult(PaginatedResult<OrderDto> Orders);

public class GetOrdersQueryHandler
            (IOrderRepository orderRepository)
    : IQueryHandler<GetOrderQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PaginatedRequest.PageSize;
        var pageNumber = request.PaginatedRequest.PageNumber;

        var totalCount = await orderRepository.GetCount(cancellationToken);

        var orders = await orderRepository.GetOrders(pageSize, pageNumber, cancellationToken);

        var ordersDto = orders.Adapt<List<OrderDto>>();

        return new GetOrderResult(new PaginatedResult<OrderDto>(pageNumber, pageSize, totalCount, ordersDto));
    }
}
