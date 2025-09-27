namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketResult(bool Success);

public class RemoveItemFromBasketHandler(BasketDbContext context)
           : ICommandHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketResult>
{
    public async Task<RemoveItemFromBasketResult> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await context.ShoppingCarts
                                       .Include(x => x.Items)
                                       .SingleOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

        if (shoppingCart is null)
            throw new BasketNotFoundException(request.UserName);

        shoppingCart.RemoveItem(request.ProductId);

        await context.SaveChangesAsync(cancellationToken);

        return new RemoveItemFromBasketResult(true);
    }
}
