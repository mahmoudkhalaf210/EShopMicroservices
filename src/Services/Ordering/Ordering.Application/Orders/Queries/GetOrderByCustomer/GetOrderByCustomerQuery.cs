

namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public record GetOrderByCustomerQuery(Guid customerId) : IQuery<GetOrderByCustomerResult>;

    public record GetOrderByCustomerResult(IEnumerable<OrderDto> orders);




}
