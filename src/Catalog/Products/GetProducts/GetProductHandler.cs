namespace Catalog.Api.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductQueryHandler(IDocumentSession session,ILogger<GetProductQueryHandler>logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
   
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var products = await session.Query<Product>().ToListAsync(cancellationToken);
                return new GetProductsResult(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while handling GetProductsQuery.");

                throw;
            }
        }
    }
}
