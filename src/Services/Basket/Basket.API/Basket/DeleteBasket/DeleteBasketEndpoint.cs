
using Basket.API.Basket.GetBasket;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketRequest(string UserName);
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) => {

                var Command = new DeleteBasketCommand(UserName);
                var result = await sender.Send(Command);
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            }).WithName("DeleteBasket")
            .Produces<DeleteBasketResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket Des");
        }
    }
}
