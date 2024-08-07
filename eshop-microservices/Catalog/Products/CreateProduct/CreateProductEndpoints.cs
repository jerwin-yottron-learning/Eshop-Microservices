using BuildingBlocks.CQRS;
using Carter;

namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResponse(Guid id);
    public class CreateProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           // app.MapPost("/products", async(CreateProductRequest request))
            throw new NotImplementedException();
        }
    }
}
