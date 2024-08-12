using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Model;

public class OrderItem : Entity<OrderItemId>
{
    public ProductId ProductId { get; private set; } = default!;
    public OrderId OrderId { get; private set; } = default!;

    public int Quantity { get; private set; } = default!;

    public decimal Price { get; private set; }

    public static OrderItem Create(OrderId orderId, ProductId productId, decimal price, int quantity)
    {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        var orderItem= new OrderItem(){
            ProductId = productId,
            OrderId = orderId,
            Quantity = quantity,
            Price = price,
            Id=OrderItemId.Of(Guid.NewGuid())
        };
        
        return orderItem;
    }
}

