namespace Catalog.Api.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductQueryHandler(IDocumentSession session,ILogger<GetProductQueryHandler>logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var products = await session.Query<Product>().
                    ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10,cancellationToken);
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
