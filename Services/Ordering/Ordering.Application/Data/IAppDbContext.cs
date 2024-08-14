using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Data
{
    public interface IAppDbContext
    {
        public DbSet<Customer> Customers { get; }
        public DbSet<Product> Products { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<OrderItem> OrderItems { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
