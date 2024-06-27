using Shopping.Web.Models.Basket;

namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Get("/basket-service/basket/{userName}")]
        Task<GetBasketResponse> GetBasket(string userName);

        [Get("/basket-service/basket")]
        Task<StoreBasketResponse> StoreBasket(StorebasketRequest request);

        [Get("/basket-service/basket/{userName}")]
        Task<DeleteBasketResponse> DeleteBasket(string userName);


        [Get("/basket-service/basket/checkout")]
        Task<CheckoutBasketResponse> checkoutBasket(CheckoutBasketRequest request);




    }
}
