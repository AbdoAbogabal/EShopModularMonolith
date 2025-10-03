namespace Basket.Data.Repository;

public class CachedBasketRepository(IBasketRepository repository,
                                    IDistributedCache cache)
          : IBasketRepository
{

    private readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new ShoppingCartConverter(), new ShoppingCartItemConverter() }
    };
    public async Task<ShoppingCart> GetBasket(string userName, bool asNoTraking, CancellationToken cancellationToken = default)
    {
        if (!asNoTraking)
            return await repository.GetBasket(userName, asNoTraking, cancellationToken);

        var basket = await cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(basket))
            return JsonSerializer.Deserialize<ShoppingCart>(basket, _options)!;

        var cachedbasket = await repository.GetBasket(userName, asNoTraking, cancellationToken);

        await cache.SetStringAsync(userName, JsonSerializer.Serialize(cachedbasket, _options), cancellationToken);

        return cachedbasket;
    }

    public async Task<ShoppingCart> CreateBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        await repository.CreateBasket(basket, cancellationToken);

        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket, _options), cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await repository.DeleteBasket(userName, cancellationToken);

        await cache.RemoveAsync(userName, cancellationToken);

        return true;
    }


    public async Task<int> SaveChangesAsync(string? userName = null, CancellationToken cancellationToken = default)
    {
        var result = await repository.SaveChangesAsync(userName, cancellationToken);

        if (userName is not null)
            await cache.RemoveAsync(userName, cancellationToken);

        return result;
    }
}
