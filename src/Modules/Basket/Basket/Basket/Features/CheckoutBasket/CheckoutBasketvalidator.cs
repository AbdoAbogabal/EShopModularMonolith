namespace Basket.Basket.Features.CheckoutBasket;

public class CheckoutBasketvalidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketvalidator()
    {
        RuleFor(e => e.BasketCheckout).NotNull().WithMessage("BasketCheckout is required");
        RuleFor(e => e.BasketCheckout.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
