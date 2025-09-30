namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemToBasketResult(Guid Id);

public class AddItemToBasketHandler(IBasketRepository basketRepository)
    : ICommandHandler<AddItemToBasketCommand, AddItemToBasketResult>
{
    public async Task<AddItemToBasketResult> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName, false, cancellationToken);

        shoppingCart.AddItem(request.ShoppingCartItem.ProductId,
                             request.ShoppingCartItem.Quantity,
                             request.ShoppingCartItem.Color,
                             request.ShoppingCartItem.Price,
                             request.ShoppingCartItem.ProductName);

        await basketRepository.SaveChangesAsync(request.UserName, cancellationToken);

        return new AddItemToBasketResult(shoppingCart.Id);
    }
}
