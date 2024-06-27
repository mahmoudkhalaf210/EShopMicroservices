namespace Shopping.Web.Models.Ordering
{
    public class OrderModel
    (
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressModel ShippingAddress,
        AddressModel BillingAddress,
        PaymentModel Payment,
        OrderStatus status,
        List<OrderItemModel> orderItems 
    );


    public record OrderItemModel(Guid OrderId , Guid ProductId , int Quantity , decimal Price);

    public record AddressModel(string FirstName , string LastName , string EmailAddress , string Addressline , string Country ,   string State,
     string ZipCOde);

    public record PaymentModel(string CardName,string CardNumber,string Expiration,string Cvv,int Paymentmethod);

    public enum OrderStatus
    {
        Draft = 1,
        Pending = 2,
        Completed = 3,
        Cancelled = 4

    }


    public record GetOrderResponse(PaginatedResult<OrderModel> paginationResponse);
    public record GetOrderByCustomerResponse(IEnumerable<OrderModel> Orders);
    public record GetOrderByNameResponse(IEnumerable<OrderModel> Orders);

}
