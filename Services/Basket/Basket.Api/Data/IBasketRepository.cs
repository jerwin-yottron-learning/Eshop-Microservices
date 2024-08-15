﻿namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken);
        Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken cancellationToken);
        Task<bool> DeleteBasket(string username, CancellationToken cancellationToken);
    }
}
