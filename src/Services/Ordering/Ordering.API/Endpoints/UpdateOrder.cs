
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints
{

    public record UpdateOrderRequest(OrderDto order);
    public record UpdateOrderResponse(bool IsSuccess);
    public class UpdateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) => {

                var commadn = request.Adapt<UpdateOrderCommand>();
                var result = await sender.Send(commadn);
                var response = result.Adapt<UpdateOrderResponse>();
                return Results.Ok(response);
            })
                .WithName("UpdateProduct")
                .Produces<UpdateOrderRequest>(statusCode: 201)
                .ProducesProblem(statusCode: 400)
                .WithSummary("Update Product")
                .WithDescription("Update Product Des");
        }

    }
}
