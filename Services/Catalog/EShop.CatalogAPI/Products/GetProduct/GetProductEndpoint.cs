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
         

            return Results.Ok(result.Product);

        });
    }
}

