

using Mapster;
using MediatR;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketRequest(string UserName);
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) => {
                var result = await sender.Send(new GetBasketQuery(username));
                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            }).WithName("GetBasket")
            .Produces<GetBasketResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket Des");
        }
    }
}
