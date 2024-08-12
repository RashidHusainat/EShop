using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Model;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(i => i.Id)
            .HasConversion(customerId => customerId.Value, gid => CustomerId.Of(gid));

        builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
        builder.Property(i => i.Email).HasMaxLength(100).IsRequired();
        builder.HasIndex(i => i.Email).IsUnique();
    }
}

