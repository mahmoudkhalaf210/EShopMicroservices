﻿


namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name , List<string> Category , string Description , string ImageFile , decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);


    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand> 
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is requied");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than Zero");

        }
    }

    internal class CreateProductCommandHandler (IDocumentSession session , ILogger<CreateProductCommandHandler> logger)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a Product

            logger.LogInformation(" CreateProductCommandHandler.handle called {@command} ", command);

      
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
            await session.SaveChangesAsync(cancellationToken);

            // 3- return CreateProductResult result
            return new CreateProductResult(product.Id);

        }
    }
}
