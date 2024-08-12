using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Model;

    public class Customer :Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get;private set; } = default!;

    public static Customer Create(CustomerId customerId,string name,string email) {

        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(email);

        return new Customer()
        {
            Id=customerId,
            Name=name,
            Email=email

        };
    
    
    }


    }

