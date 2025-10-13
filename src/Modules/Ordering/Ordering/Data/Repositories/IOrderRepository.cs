


namespace Ordering.Data.Repositories;

public interface IOrderRepository
{
    Task<Order> CreateOrder(CreateOrderCommand command, CancellationToken cancellationToken);
    Task<bool> DeleteOrder(Guid id, CancellationToken cancellationToken);
    Task<int> GetCount(CancellationToken cancellationToken);
    Task<Order> GetOrderById(Guid id, CancellationToken cancellationToken);
    Task<List<Order>> GetOrders(int pageSize, int pageNumber, CancellationToken cancellationToken);
}
