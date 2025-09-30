﻿namespace Basket.Data.Repository;

public interface IBasketRepository
{
    Task<int> SaveChangesAsync(string? userName = null, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> CreateBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
    Task<ShoppingCart> GetBasket(string userName, bool asNoTraking, CancellationToken cancellationToken = default);
}
