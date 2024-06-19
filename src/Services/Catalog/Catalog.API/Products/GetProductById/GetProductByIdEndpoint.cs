
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdRequest(Guid id);
    public record GetProductByIdResponse(Product Product);

    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) => {

                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            
            })
             .WithName("Get Product by ID")
            .Produces<GetProductByIdResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Get Product by ID")
            .WithDescription("Get Product by ID"); 
        }
    }
}
