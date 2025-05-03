

using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Create product entity
        var product = new Product
        {
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.price,
            Name = command.Name,
        };

        //TODO: Save to database
        //Save to database

        //return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}

