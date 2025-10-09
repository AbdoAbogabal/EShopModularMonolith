namespace Ordering.Orders.Features.GetOrders;

public record GetOrderResult(PaginatedResult<OrderDto> Orders);

public class GetOrdersQueryHandler
            (OrderingDbContext context)
    : IQueryHandler<GetOrderQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PaginatedRequest.PageSize;
        var pageNumber = request.PaginatedRequest.PageNumber;

        var totalCount = await context.Orders.LongCountAsync(cancellationToken);

        var orders = await context.Orders.AsNoTracking()
                                         .Include(e => e.Items)
                                         .Skip(pageSize * pageNumber)
                                         .Take(pageSize)
                                         .ToListAsync(cancellationToken);

        var ordersDto = orders.Adapt<List<OrderDto>>();

        return new GetOrderResult(new PaginatedResult<OrderDto>(pageNumber, pageSize, totalCount, ordersDto));
    }
}
