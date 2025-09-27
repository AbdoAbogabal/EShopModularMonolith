namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemToBasketResult(Guid Id);

public class AddItemToBasketHandler(BasketDbContext context)
    : ICommandHandler<AddItemToBasketCommand, AddItemToBasketResult>
{
    public async Task<AddItemToBasketResult> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await context.ShoppingCarts
                                        .Include(x => x.Items)
                                        .SingleOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

        if (shoppingCart is null)
            throw new BasketNotFoundException(request.UserName);

        shoppingCart.AddItem(request.ShoppingCartItem.ProductId,
                             request.ShoppingCartItem.Quantity,
                             request.ShoppingCartItem.Color,
                             request.ShoppingCartItem.Price,
                             request.ShoppingCartItem.ProductName);

        await context.SaveChangesAsync(cancellationToken);

        return new AddItemToBasketResult(shoppingCart.Id);
    }
}
