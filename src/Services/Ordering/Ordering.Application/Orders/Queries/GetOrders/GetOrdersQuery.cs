
using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginatedRequest paginationRequest) : IQuery<GetOrdersResult>;
    
    public record GetOrdersResult(PaginatedResult<OrderDto> orders);

}
