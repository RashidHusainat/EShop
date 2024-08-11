using Carter;
using MediatR;

namespace EShop.CatalogAPI.Products.UpdateProduct;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            if (result is null)
                throw new Exception();

            return Results.Ok(result.IsSuccess);

        });
    }
}

