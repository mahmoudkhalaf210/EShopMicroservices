
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductByCatgory
{
    public record GetProductByCategoryRequest(string Category);
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) => {

                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
        
            })
             .WithName("Get Product by Category")
            .Produces<CreateProductResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Get Product by Category")
            .WithDescription("Get Product by Category");
        }
    }
}
