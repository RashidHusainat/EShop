using Ordering.Domain.Model;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture.Data.Extentions;

public static class InitData
{
    public static Customer[] GetCustomers()
    {
        return new Customer[]
        {
            Customer.Create(CustomerId.Of(Guid.NewGuid()),"Samer Alkhatib","Samer@yahoo.com"),
            Customer.Create(CustomerId.Of(Guid.NewGuid()),"Kofahi","Kofahi@yahoo.com"),
            Customer.Create(CustomerId.Of(Guid.NewGuid()),"Rashid Husainat","Rashid@yahoo.com"),

        };


    }

    public static Product[] GetProducts()
    {
        return new Product[]
        {
            Product.Create(ProductId.Of(Guid.NewGuid()),"IPhone X",500),
            Product.Create(ProductId.Of(Guid.NewGuid()),"Samsung Galaxy S3",100),
            Product.Create(ProductId.Of(Guid.NewGuid()),"Hawaui",200),

        };


    }
}

