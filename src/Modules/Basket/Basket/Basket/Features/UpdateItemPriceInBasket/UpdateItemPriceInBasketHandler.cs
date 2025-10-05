namespace Basket.Basket.Features.UpdateItemPriceInBasket;

public record UpdateItemPriceInBasketResult(bool IsSuccess);

public class UpdateItemPriceInBasketValidator : AbstractValidator<UpdateItemPriceInBasketCommand>
{
    public UpdateItemPriceInBasketValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

public class UpdateItemPriceInBasketHandler(BasketDbContext context)
           : ICommandHandler<UpdateItemPriceInBasketCommand, UpdateItemPriceInBasketResult>
{
    public async Task<UpdateItemPriceInBasketResult> Handle(UpdateItemPriceInBasketCommand command, CancellationToken cancellationToken)
    {
        var itemsToBeUpdate = await context.ShoppingCartItems
                                           .Where(e => e.ProductId.Equals(command.ProductId))
                                           .ToListAsync(cancellationToken);

        if (!itemsToBeUpdate.Any())
            return new UpdateItemPriceInBasketResult(false);

        foreach (var item in itemsToBeUpdate)
            item.UpdatePrice(command.Price);

        await context.SaveChangesAsync(cancellationToken);

        return new UpdateItemPriceInBasketResult(true);

    }
}
