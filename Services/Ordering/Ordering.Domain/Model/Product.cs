using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ordering.Domain.Model;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;

    public decimal Price { get; private set; } = default!;

    public static Product Create(ProductId productId,string name ,decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        return new Product()
        {
            Name = name,
            Price = price,
            Id = productId
        };

    }
}

