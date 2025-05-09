
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductResult(bool IsSuccess);
    public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    internal class UpdateProductCommandHandler(IDocumentSession session,ILogger<UpdateProductCommandHandler> logger) 
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called with {@command}",command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException();
            product.Name = command.Name;
            product.Price = command.Price;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Category = command.Category;

            session.Update(product);

            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
