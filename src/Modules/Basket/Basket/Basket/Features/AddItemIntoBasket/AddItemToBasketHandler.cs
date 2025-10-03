 namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemToBasketResult(Guid Id);

public class AddItemToBasketHandler(IBasketRepository basketRepository, ISender sender)
    : ICommandHandler<AddItemToBasketCommand, AddItemToBasketResult>
{
    public async Task<AddItemToBasketResult> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName, false, cancellationToken);

        var result = await sender.Send(new GetProductsByIdQuery(request.ShoppingCartItem.ProductId), cancellationToken);

        shoppingCart.AddItem(request.ShoppingCartItem.ProductId,
                             request.ShoppingCartItem.Quantity,
                             request.ShoppingCartItem.Color,
                             result.Product.Price,
                             result.Product.Name);

        await basketRepository.SaveChangesAsync(request.UserName, cancellationToken);

        return new AddItemToBasketResult(shoppingCart.Id);
    }
}
