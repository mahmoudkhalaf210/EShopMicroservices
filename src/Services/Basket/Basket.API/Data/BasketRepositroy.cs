
namespace Basket.API.Data
{
    public class BasketRepositroy (IDocumentSession session)
        : IBasketRepositroy
    {

 
        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancelationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(UserName, cancelationToken);
            if (basket is null) throw new BasketNotFoundException(UserName);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }

        public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(UserName);
            await session.SaveChangesAsync(cancellationToken);  
            return true;
        }



    }
}
