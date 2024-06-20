


namespace Basket.API.Basket.StoreBasket
{
   public record StorebasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);

    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StorebasketRequest request, ISender sender) => {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{response.UserName}", response);
              //  return Results.Ok(response);
            }).WithName("StoreBasket")
            .Produces<StoreBasketResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket Des");
        }
    }
}
