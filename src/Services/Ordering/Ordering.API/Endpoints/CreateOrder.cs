namespace Ordering.API.Endpoints
{
    public record CreateOrderRequest(OrderDto Order);

    public record CreateOrderResponse(Guid Id);

    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) => {
                var command = request.Adapt<CreateOrderCommand>();
                var result = sender.Send(command);
                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);
            
            })
            .WithName("CreateOrder")
            .Produces<CreateOrderResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Create Order")
            .WithDescription("Create Order Des");
        }
    }
}
