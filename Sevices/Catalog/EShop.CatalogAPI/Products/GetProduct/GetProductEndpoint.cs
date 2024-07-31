using Carter;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProduct;

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
          var result=await sender.Send(new GetProductQuery() { Id=id});
            if (result.Product is null)
                return Results.NotFound();

            return Results.Ok(result.Product);

        });
    }
}

