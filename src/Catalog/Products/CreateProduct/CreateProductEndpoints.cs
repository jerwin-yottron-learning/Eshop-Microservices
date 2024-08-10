﻿namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>
    {
    
    }

    public record CreateProductResponse(Guid id);
    public class CreateProductEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products/{response.id}", response);

            }).WithName("CreateProduct")
               .Produces<CreateProductResponse>(StatusCodes.Status201Created)
               .WithSummary("Create Product")
               .WithDescription("Create Product");
        }
    }
}