using Ordering.Domain.Abstraction;
using Ordering.Domain.Enum;
using Ordering.Domain.Events;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Model;

public class Order : Aggregate<OrderId>
{
    private List<OrderItem> _orderItems = new();

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    public string OrderName { get; private set; } = default!;

    public CustomerId CustomerId { get; private set; } = default!;

    public ProductId ProductId { get; private set; } = default!;

    public OrderStatus Status { get; private set; } = default!;

    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;

    public Payment Payment { get; private set; } = default!;

    public decimal TotalPrice
    {
        get
        {
            return _orderItems.Sum(i => i.Price * i.Quantity);
        }
        private set { }
    }

    public static Order Create(string orderName, Address shippingAddress, Address billingAddress,
        Payment payment, OrderId orderId, CustomerId customerId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(orderName);
        var order= new Order()
        {
            Status=OrderStatus.Draf,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Id= orderId,

        };
        order.AddDomainEvent(new OrderCreateEvent(order));

        return order;
        
    }

    public  void Update(string orderName, Address shippingAddress, Address billingAddress,Payment payment,OrderStatus status)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(orderName);
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedEvent(this));

    }

    public void Add(ProductId productId, int quantity,decimal price) {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        _orderItems.Add(OrderItem.Create(Id, productId, price, quantity));

    }

    public void Remove(ProductId productId) {
    var item=_orderItems.FirstOrDefault(i=>i.ProductId==productId);
        if(item is not null)
            _orderItems.Remove(item);
    
    }


}

