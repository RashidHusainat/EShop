using Ordering.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Dtos;

    public class OrderDto
    {
    public Guid Id { get; set; } = default!;
    public Guid CustomerId { get; set; } = default!;

    public string OrderName { get; set; } = default!;
    public AddressDto ShippingAddress { get; set; } = default!;
    public AddressDto BillingAddress { get; set; } = default!;
    public PaymentDto Payment { get; set; } = default!;
    public OrderStatus Status { get; set; } = default!;
    public List<OrderItemDto> OrderItem { get; set; } = default!;
}

