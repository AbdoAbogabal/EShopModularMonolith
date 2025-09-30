namespace Basket.Basket.Features.CreateBasket;

public record CreateBasketResult(Guid Id);

public class CreateBasketHandler(IBasketRepository basketRepository)
    : ICommandHandler<CreateBasketCommand, CreateBasketResult>
{
    public async Task<CreateBasketResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = CreateNewBasket(request.ShoppingCart);

        await basketRepository.CreateBasket(shoppingCart, cancellationToken);

        return new CreateBasketResult(shoppingCart.Id);
    }

    private ShoppingCart CreateNewBasket(ShoppingCartDto shoppingCart)
    {

        var newBasket = ShoppingCart.CreateNew(shoppingCart.Id, shoppingCart.UserName);

        shoppingCart.Items.ForEach(item =>
                                  newBasket.AddItem(item.ProductId,
                                  item.Quantity,
                                  item.Color,
                                  item.Price,
                                  item.ProductName));

        return newBasket;

    }
}
