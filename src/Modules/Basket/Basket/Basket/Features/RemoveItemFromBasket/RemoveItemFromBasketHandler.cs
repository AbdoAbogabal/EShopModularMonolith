namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketResult(bool IsSuccess);

public class RemoveItemFromBasketHandler(IBasketRepository basketRepository)
           : ICommandHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketResult>
{
    public async Task<RemoveItemFromBasketResult> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName, false, cancellationToken);

        shoppingCart.RemoveItem(request.ProductId);

        await basketRepository.SaveChangesAsync(request.UserName, cancellationToken);

        return new RemoveItemFromBasketResult(true);
    }
}
