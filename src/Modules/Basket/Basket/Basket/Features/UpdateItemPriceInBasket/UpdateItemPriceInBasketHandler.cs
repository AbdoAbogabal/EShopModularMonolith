namespace Basket.Basket.Features.UpdateItemPriceInBasket;

public record UpdateItemPriceInBasketResult(bool IsSuccess);

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
