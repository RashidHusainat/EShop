using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public class OrderItemId
    {
        public Guid Value { get; private set; } = default!;

        private OrderItemId(Guid value) 
        { 
            Value = value; 
        }

        public static OrderItemId Of(Guid value)
        {
            return new OrderItemId(value);
        }
    }
}
