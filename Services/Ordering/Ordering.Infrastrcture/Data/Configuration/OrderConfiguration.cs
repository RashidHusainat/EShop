using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enum;
using Ordering.Domain.Model;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastrcture.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(orderId => orderId.Value, gid => OrderId.Of(gid));

            builder.Property(x => x.OrderName).IsRequired();

            builder.HasMany<OrderItem>().WithOne()
                .HasForeignKey(x => x.OrderId);

            builder.HasOne<Customer>().WithMany()
                .HasForeignKey(x => x.CustomerId);

            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.Pending);



            builder.ComplexProperty(
          o => o.ShippingAddress, addressBuilder =>
          {
              addressBuilder.Property(a => a.FirstName)
                  .HasMaxLength(50)
                  .IsRequired();

              addressBuilder.Property(a => a.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

              addressBuilder.Property(a => a.EmailAddress)
                  .HasMaxLength(50);

              addressBuilder.Property(a => a.AddressLine)
                  .HasMaxLength(180)
                  .IsRequired();

              addressBuilder.Property(a => a.Country)
                  .HasMaxLength(50);

              addressBuilder.Property(a => a.State)
                  .HasMaxLength(50);

              addressBuilder.Property(a => a.ZipCode)
                  .HasMaxLength(5)
                  .IsRequired();
          });

            builder.ComplexProperty(
              o => o.BillingAddress, addressBuilder =>
              {
                  addressBuilder.Property(a => a.FirstName)
                       .HasMaxLength(50)
                       .IsRequired();

                  addressBuilder.Property(a => a.LastName)
                       .HasMaxLength(50)
                       .IsRequired();

                  addressBuilder.Property(a => a.EmailAddress)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.AddressLine)
                      .HasMaxLength(180)
                      .IsRequired();

                  addressBuilder.Property(a => a.Country)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.State)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.ZipCode)
                      .HasMaxLength(5)
                      .IsRequired();
              });

            builder.ComplexProperty(
                   o => o.Payment, paymentBuilder =>
                   {
                       paymentBuilder.Property(p => p.CardName)
                           .HasMaxLength(50);

                       paymentBuilder.Property(p => p.CardNumber)
                           .HasMaxLength(24)
                           .IsRequired();

                       paymentBuilder.Property(p => p.Expiration)
                           .HasMaxLength(10);

                       paymentBuilder.Property(p => p.CVV)
                           .HasMaxLength(3);

                       paymentBuilder.Property(p => p.PaymentMethod);
                   });
        }
    }
}
