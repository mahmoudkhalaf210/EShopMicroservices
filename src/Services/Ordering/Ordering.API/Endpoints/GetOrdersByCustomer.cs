
using Ordering.Application.Orders.Queries.GetOrderByCustomer;

namespace Ordering.API.Endpoints
{
    public record GetOrdersByCustomerRequest(Guid customerId);
    public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);

    public class GetOrdersByCustomer : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) => {

                var result = await sender.Send(new GetOrderByCustomerQuery(customerId));
                var response = result.Adapt<GetOrderByCustomerResponse>();
                return Results.Ok(response);
            })
                .WithName("GetOrdersByCustomerId")
                .Produces<GetOrderByCustomerResponse>(statusCode: 201)
                .ProducesProblem(statusCode: 400)
                .WithSummary("Get Order by CustomerID")
                .WithDescription("Get Order by CustomerID  Des");
        }
    }
}
