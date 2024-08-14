using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries
{
    public class GetOrdersQueryHandler(IAppDbContext appDbContext) : IRequestHandler<GetOrdersQuery, GetOrdersQueryResult>
    {
        public async Task<GetOrdersQueryResult> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await appDbContext.Orders.Include(a=>a.OrderItems).ToListAsync();
            var list = OrderListToOrderDtoList(orders);
            return new GetOrdersQueryResult()
            {
                OrderDto = list
            };
        }

        private List<OrderDto> OrderListToOrderDtoList(List<Order> orders) { 
        return orders.Select(order=>new OrderDto
        { 
        BillingAddress=order.BillingAddress.Adapt<AddressDto>(),
        ShippingAddress=order.ShippingAddress.Adapt<AddressDto>(),
        Payment=order.Payment.Adapt<PaymentDto>(),
        OrderName=order.OrderName,
        CustomerId=order.CustomerId.Value,
        Id=order.Id.Value,
        Status=order.Status,
        OrderItem=order.OrderItems.Select(oi => new OrderItemDto
        {
            OrderId=oi.OrderId.Value,
            Price=oi.Price,
            ProductId=oi.ProductId.Value,
            Quantity=oi.Quantity

        }).ToList(),

        
        }).ToList();



        }
    }
}
