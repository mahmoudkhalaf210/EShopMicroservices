
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);


    internal class GetProductByIdQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            //  var product = await session.Query<Product>().Where(p => p.Id == query.id).SingleOrDefaultAsync(cancellationToken);
            var product = await session.LoadAsync<Product>(query.id, cancellationToken);
            if (product is null) {
                throw new ProductNotFoundException(query.id);
            }
            return new GetProductByIdResult(product);
        }
    }

}
