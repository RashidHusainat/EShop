using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects;

public class OrderId
{
    public Guid Value { get; private set; } = default!;

    private OrderId(Guid value)
    {
        Value = value;
    }

    public static OrderId Of(Guid value)
    {
        return new OrderId(value);
    }
}

