namespace Basket.Basket.Features.CreateBasket;

public class CreateBasketValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketValidator()
    {
        RuleFor(e => e.ShoppingCart.UserName).NotEmpty().WithMessage("Username is required");
    }
}
