using Carter;
using MediatR;
using OpenTelemetry.Trace;

namespace EShop.CatalogAPI.Products.CreateProduct;

    public class CreateProductEndpoint : ICarterModule
    {
        public void  AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products", async (ISender sender,CreateProductCommand command) =>
            {
                var result =await sender.Send(command);

                return Results.Ok();
            });
        }
    }

