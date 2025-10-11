namespace Basket.Basket.Features.CheckoutBasket;

public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketHandler(BasketDbContext context)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var basket = await context.ShoppingCarts.Include(e => e.Items)
                                                    .SingleOrDefaultAsync(e => e.UserName.Equals(command.BasketCheckout.UserName), cancellationToken)
                                                    ?? throw new BasketNotFoundException(command.BasketCheckout.UserName);

            var eventMessage = command.BasketCheckout.Adapt<BasketCheckoutIntegrationEvent>();
            eventMessage.Totalprice = basket.TotalPrice;

            var outboxMessage = new OutboxMessage()
            {
                Id = Guid.NewGuid(),
                OccuredOn = DateTime.UtcNow,
                Content = JsonSerializer.Serialize(eventMessage),
                Type = typeof(BasketCheckoutIntegrationEvent).AssemblyQualifiedName!,
            };

            context.OutboxMessages.Add(outboxMessage);

            context.ShoppingCarts.Remove(basket);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return new CheckoutBasketResult(true);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return new CheckoutBasketResult(false);
        }
    }
}
