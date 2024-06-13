
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products" , async(ISender sender)=>{
                var result = await sender.Send(new GetProductsQuery());
                var response  = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<CreateProductResponse>(statusCode: 201)
            .ProducesProblem(statusCode: 400)
            .WithSummary("Get Product")
            .WithDescription("Get Product Des"); 
        }
    }
}
