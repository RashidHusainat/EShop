using Carter;
using MediatR;

namespace EShop.CatalogAPI.Products.DeleteProduct;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result=await sender.Send(new DeleteProductCommand() { Id = id });

            return Results.Ok(result.IsSuccess);

        });
    }
}

