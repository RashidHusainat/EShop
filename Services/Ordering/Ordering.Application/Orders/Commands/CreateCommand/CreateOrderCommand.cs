using MediatR;
using Ordering.Application.Dtos;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Commands.CreateCommand;

public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
{
    public OrderDto OrderDto { get; set; }
}

public class CreateOrderCommandResult
{
    public OrderId OrderId { get; set; }
}

