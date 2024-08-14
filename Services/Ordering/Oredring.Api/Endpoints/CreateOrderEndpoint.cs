using Carter;
using MediatR;
using Ordering.Application.Orders.Commands.CreateCommand;

namespace Oredring.Api.Endpoints;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders",async (CreateOrderCommand command, ISender sender) => {

            var result = await sender.Send(command);
            return Results.Created($"/orders/{result.OrderId.Value}",result.OrderId.Value);
        
        }).WithName("CreateOrder")
        .Produces<CreateOrderCommand>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}

