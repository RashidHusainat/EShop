using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Domain.Model;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ordering.Application.Orders.Commands.CreateCommand;

public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderDto.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.OrderDto.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.OrderDto.OrderItem).NotEmpty().WithMessage("OrderItems should not be empty");
    }

}
public class CreateOrderCommandHandler(IAppDbContext appDbContext)
    : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
{

    public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(request.OrderDto);

        appDbContext.Orders.Add(order);
        await appDbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderCommandResult()
        {
            OrderId = order.Id
        };
    }

    private Order CreateNewOrder(OrderDto orderDto)
    {
        var shippingAddress=Address.Of(orderDto.ShippingAddress.FirstName, 
            orderDto.ShippingAddress.LastName,
            orderDto.ShippingAddress.EmailAddress,
            orderDto.ShippingAddress.AddressLine,
            orderDto.ShippingAddress.Country,
            orderDto.ShippingAddress.State,
            orderDto.ShippingAddress.ZipCode);

        var billingAddress = Address.Of(orderDto.BillingAddress.FirstName,
           orderDto.BillingAddress.LastName,
           orderDto.BillingAddress.EmailAddress,
           orderDto.BillingAddress.AddressLine,
           orderDto.BillingAddress.Country,
           orderDto.BillingAddress.State,
           orderDto.BillingAddress.ZipCode);

        var payment = Payment.Of(orderDto.Payment.CardName
            , orderDto.Payment.CardNumber,
            orderDto.Payment.Expiration,
            orderDto.Payment.Cvv,
            orderDto.Payment.PaymentMethod);

        var order = Order.Create(orderDto.OrderName, shippingAddress,
            billingAddress, payment,OrderId.Of(Guid.NewGuid()),
            CustomerId.Of(orderDto.CustomerId));

        foreach (var orderItem in orderDto.OrderItem)
        {
            order.Add(ProductId.Of(orderItem.ProductId), orderItem.Quantity, orderItem.Price);
        }

        return order;
    }
}

