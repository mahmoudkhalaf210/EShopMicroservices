
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest(int? PageNumber = 1 , int? PageSize = 5);
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products" , async([AsParameters] GetProductsRequest request, ISender sender)=>{
                var query = request.Adapt<GetProductsQuery>();

                var result = await sender.Send(query);
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
