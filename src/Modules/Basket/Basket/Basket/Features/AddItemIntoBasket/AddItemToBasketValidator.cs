namespace Basket.Basket.Features.AddItemIntoBasket;
public class AddItemToBasketValidator : AbstractValidator<AddItemToBasketCommand>
{
    public AddItemToBasketValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.ShoppingCartItem.Quantity).NotEmpty().WithMessage("Quantity is required");
        RuleFor(x => x.ShoppingCartItem.ProductId).NotEmpty().WithMessage("ProductId is required");
    }
}
