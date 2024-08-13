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

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
   

    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(orderItem => orderItem.Value, gid => OrderItemId.Of(gid));
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.Price).IsRequired();
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }
}

