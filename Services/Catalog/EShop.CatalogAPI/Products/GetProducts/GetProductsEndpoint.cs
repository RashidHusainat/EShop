using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.CatalogAPI.Products.GetProduct;

public class GetProductRequest
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}
public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([FromBody]GetProductRequest request,[FromServices]ISender sender) =>
        {
            var mappedQuery = request.Adapt<GetProductsQuery>();
            var result = await sender.Send(mappedQuery);
            return Results.Ok(result.Products);
        });
    }
}

