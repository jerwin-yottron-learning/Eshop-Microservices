namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid id);

    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        /// <summary>
        /// Create product entity from command object
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
             Name = command.Name,
             Description = command.Description,
             Category = command.Category,
             ImageFile = command.ImageFile,
             Price = command.Price
            };
            //save to the database using marten library 
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
