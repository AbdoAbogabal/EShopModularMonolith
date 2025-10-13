namespace Ordering.Orders.Features.CreateOrder;

public record CreateOrderResult(Guid OrderId);

public class CreateOrderCommandHandler
             (IOrderRepository orderRepository)
             : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await orderRepository.CreateOrder(command, cancellationToken);

        return new CreateOrderResult(order.Id);
    }
}
