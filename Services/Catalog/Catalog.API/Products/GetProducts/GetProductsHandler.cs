
namespace Catalog.API.Products.GetProducts
{
    public record GetProductResult(IEnumerable<Product> Products);
    public record GetProductsQuery() : IQuery<GetProductResult>;
    internal class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductsQueryHandler.Handle called with {query}");

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);
        }
    }
}
