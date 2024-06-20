namespace Basket.API.Data
{
    public interface IBasketRepositroy
    {
        Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancelationToken = default);
        Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);

        Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default);

    }
}
