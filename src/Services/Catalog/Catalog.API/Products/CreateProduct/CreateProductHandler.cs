

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name , List<string> Category , string Description , string ImageFile , decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler (IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a Product


            // 1- create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // 2- save the database
            session.Store(product);
            await session.SaveChangesAsync();

            // 3- return CreateProductResult result
            return new CreateProductResult(product.Id);

        }
    }
}
