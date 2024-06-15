
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender sender) => {

                var result = await sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            }).WithName("DeleteProduct")
            .Produces<CreateProductResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product Des");
        }
    }
}
