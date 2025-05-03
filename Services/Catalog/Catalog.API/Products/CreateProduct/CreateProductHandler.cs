

using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal price)
    : ICommand<CreateProductResponse>;
public record CreateProductResponse(Guid Id);
public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

