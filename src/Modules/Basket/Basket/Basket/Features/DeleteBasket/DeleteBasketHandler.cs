namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketResult(bool Success);

public class DeleteBasketHandler(BasketDbContext context) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(request.UserName);

        var basket = await context.ShoppingCarts
                                  .SingleOrDefaultAsync(e => e.UserName.Equals(request.UserName), cancellationToken);

        if (basket is null)
            throw new BasketNotFoundException(request.UserName);

        context.ShoppingCarts.Remove(basket);

        await context.SaveChangesAsync(cancellationToken);

        return new DeleteBasketResult(true);
    }
}
