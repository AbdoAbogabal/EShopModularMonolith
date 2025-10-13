namespace Basket.Basket.Features.UpdateItemPriceInBasket;

public class UpdateItemPriceInBasketValidator : AbstractValidator<UpdateItemPriceInBasketCommand>
{
    public UpdateItemPriceInBasketValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
