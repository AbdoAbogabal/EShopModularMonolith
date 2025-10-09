namespace Ordering.Orders.Features.GetOrders;

public record GetOrderQuery(PaginatedRequest PaginatedRequest) : IQuery<GetOrderResult>;
