using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(
                orderid => orderid.Value,
                DbId => OrderId.Of(DbId)
                );

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            // many items to one order 
            // foreign key in item ==> orderid
            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);



            builder.ComplexProperty(
                o => o.OrderName, nameBuilder => {
                    nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
                });


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

                    addressBuilder.Property(a => a.ZipCOde)
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

                   addressBuilder.Property(a => a.ZipCOde)
                   .HasMaxLength(5)
                   .IsRequired();
               });


            builder.ComplexProperty(
                o => o.Payment, Paymentbuilder =>
                {
                    Paymentbuilder.Property(p => p.CardName)
                    .HasMaxLength(50);

                    Paymentbuilder.Property(p => p.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                    Paymentbuilder.Property(p => p.Expiration)
                    .HasMaxLength(10);

                    Paymentbuilder.Property(p => p.CVV)
                    .HasMaxLength(3)
                    .IsRequired();

                    Paymentbuilder.Property(p => p.PaymentMethod)

                });


            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus)
                );


            builder.Property(o => o.TotalPrice);

        }
    }
}
