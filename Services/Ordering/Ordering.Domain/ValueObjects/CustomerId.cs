using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects;

    public class CustomerId
    {
    public Guid Value { get; private set; } = default!;

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId Of(Guid value)
    {
        return new CustomerId(value);
    }
}

