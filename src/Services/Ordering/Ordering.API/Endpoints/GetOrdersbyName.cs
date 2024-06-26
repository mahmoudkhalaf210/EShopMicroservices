
using Ordering.Application.Orders.Queries.GetOrderByName;
using Ordering.Domain.ValueObjects;

namespace Ordering.API.Endpoints
{
    public record GetOrderByNameRequest(string Name);
    public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersbyName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) => {

                var result = await sender.Send(new GetOrderByNameQuery(orderName));
                var response = result.Adapt<GetOrderByNameResponse>();
                return Results.Ok(response);
            })
                .WithName("GetOrderByName")
                .Produces<GetOrderByNameRequest>(statusCode: 201)
                .ProducesProblem(statusCode: 400)
                .WithSummary("Get Orders By Name")
                .WithDescription("Get Orders By Name Des");
        }
    }
}
