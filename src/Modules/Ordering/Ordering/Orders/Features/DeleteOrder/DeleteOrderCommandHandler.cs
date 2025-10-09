namespace Ordering.Orders.Features.DeleteOrder;

public record DeleteOrderResult(bool IsSuccess);

public class DeleteOrderCommandHandler
            (OrderingDbContext context)
            : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FindAsync([command.OrderId], cancellationToken);

        if (order is null) throw new OrderNotFoundException(command.OrderId);

        context.Orders.Remove(order);
        await context.SaveChangesAsync(cancellationToken);
        return new DeleteOrderResult(true);

    }
}
