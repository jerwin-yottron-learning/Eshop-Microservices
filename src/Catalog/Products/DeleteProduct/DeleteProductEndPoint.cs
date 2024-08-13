
using Catalog.API.Products.UpdateProduct;

namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);

    public record DeleteProductResponse(bool IsDeleted);
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender sender) =>
            {
                var result =sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
            .WithName("Delete Product")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
        }
    }
}
