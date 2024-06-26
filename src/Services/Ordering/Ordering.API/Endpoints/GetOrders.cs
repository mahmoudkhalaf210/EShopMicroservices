using Azure.Core;
using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{
    public record GetOrdersRequest(PaginatedRequest paginationRequest);
    public record GetOrderResponse(PaginatedResult<OrderDto> paginationResponse);

    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginatedRequest request, ISender sender) => {

                var result = await sender.Send(new GetOrdersQuery(request));
               // var response = result.Adapt<GetOrderResponse>();
                return Results.Ok(result);
            })
                .WithName("GetOrders")
                .Produces<PaginatedResult<OrderDto>>(statusCode: 201)
                .ProducesProblem(statusCode: 400)
                .WithSummary("GetOrders ")
                .WithDescription("GetOrders  Des");
        }
    }
}
