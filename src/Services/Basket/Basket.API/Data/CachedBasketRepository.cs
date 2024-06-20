
namespace Basket.API.Data
{
    public class CachedBasketRepository (IBasketRepositroy repository)
        : IBasketRepositroy
    {
      

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancelationToken = default)
        {
            return await repository.GetBasket(UserName, cancelationToken);
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            return await repository.StoreBasket(basket, cancellationToken);
        }
        public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default)
        {
            return await repository.DeleteBasket(UserName, cancellationToken);
        }
    }
}
