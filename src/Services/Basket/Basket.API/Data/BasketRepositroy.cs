
namespace Basket.API.Data
{
    public class BasketRepositroy : IBasketRepositroy
    {

        public Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancelationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
