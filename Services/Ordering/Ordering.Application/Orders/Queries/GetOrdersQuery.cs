using MediatR;
using Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries
{
    public class GetOrdersQuery:IRequest<GetOrdersQueryResult>
    {
       
    }

    public class GetOrdersQueryResult
    {
        public List<OrderDto> OrderDto { get; set; }
    }
}
