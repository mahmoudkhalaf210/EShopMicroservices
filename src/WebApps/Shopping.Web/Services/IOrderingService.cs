using Shopping.Web.Models.Ordering;

namespace Shopping.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
        Task<GetOrderResponse> GetOrders(int? pageIndex = 1, int? pageSize = 10);
        [Get("/ordering-service/orders/{orderName}")]
        Task<GetOrderByNameResponse> GetOrderByName(string orderName);
        [Get("/ordering-service/orders/{customerId}")]
        Task<GetOrderByCustomerResponse> GetOrderByCustomer(Guid customerId);

    }
}
