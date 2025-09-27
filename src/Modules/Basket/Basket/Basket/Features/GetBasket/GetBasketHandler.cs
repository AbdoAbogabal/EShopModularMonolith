namespace Basket.Basket.Features.GetBasket;

public record GetBasketResult(ShoppingCartDto ShoppingCart);

public class GetBasketHandler(BasketDbContext context)
           : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await context.ShoppingCarts
                                  .AsNoTracking()
                                  .Include(s => s.Items)
                                  .SingleOrDefaultAsync(e => e.UserName.Equals(request.UserName), cancellationToken);

        if (basket is null)
            throw new BasketNotFoundException(request.UserName);

        var basketDto = basket.Adapt<ShoppingCartDto>();

        return new GetBasketResult(basketDto);
    }
}
