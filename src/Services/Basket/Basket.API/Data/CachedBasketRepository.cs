

namespace Basket.API.Data
{
    public class CachedBasketRepository (IBasketRepositroy repository , IDistributedCache cache)
        : IBasketRepositroy
    {
      

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancelationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(UserName , cancelationToken);
            if (!string.IsNullOrEmpty(cachedBasket))
               return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

            var basket = await repository.GetBasket(UserName, cancelationToken);
            await cache.SetStringAsync(UserName , JsonSerializer.Serialize(basket) , cancelationToken);

            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
             await repository.StoreBasket(basket, cancellationToken);
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket) , cancellationToken);
            return basket;

        }
        public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default)
        {
             await repository.DeleteBasket(UserName, cancellationToken);
            await cache.RemoveAsync(UserName, cancellationToken);
            return true;
        }
    }
}
