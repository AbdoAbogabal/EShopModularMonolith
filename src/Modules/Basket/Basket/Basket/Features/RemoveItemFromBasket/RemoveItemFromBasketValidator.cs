namespace Basket.Basket.Features.RemoveItemFromBasket;

public class RemoveItemFromBasketValidator : AbstractValidator<RemoveItemFromBasketCommand>
{
    public RemoveItemFromBasketValidator()
    {
        RuleFor(e => e.UserName).NotEmpty().WithMessage("UserName is required.");
        RuleFor(e => e.ProductId).NotEmpty().WithMessage("ProductId is required.");
    }
}