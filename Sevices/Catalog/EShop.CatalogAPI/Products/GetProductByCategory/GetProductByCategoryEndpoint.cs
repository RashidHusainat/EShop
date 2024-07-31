using Carter;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProductByCategory;

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string? category, ISender sender) =>
        {
            var result=await sender.Send(new GetProductByCategoryQuery() { Category = category });

            return Results.Ok(result.Products);

        });
    }
}

