using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Basket.DeleteBasket
{
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket", async ([FromBody]DeleteBasketCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return Results.Ok(result);
            });
        }
    }
}
