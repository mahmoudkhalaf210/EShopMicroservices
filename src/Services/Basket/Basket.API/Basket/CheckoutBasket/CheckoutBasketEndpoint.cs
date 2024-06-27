

using Basket.API.Basket.DeleteBasket;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketRequest(BasketCheckoutDto basketCheckoutDto);

    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckoutBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) => {

                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CheckoutBasketResponse>();
                return Results.Ok(response);
            }).WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Checkout Basket")
            .WithDescription("Checkout Basket Des");
        }
    }
}
