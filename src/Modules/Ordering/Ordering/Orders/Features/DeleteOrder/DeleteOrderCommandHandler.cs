namespace Ordering.Orders.Features.DeleteOrder;

public record DeleteOrderResult(bool IsSuccess);

public class DeleteOrderCommandHandler
            (IOrderRepository orderRepository)
            : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        bool isSuccess = await orderRepository.DeleteOrder(command.OrderId, cancellationToken);

        return new DeleteOrderResult(isSuccess);
    }
}
