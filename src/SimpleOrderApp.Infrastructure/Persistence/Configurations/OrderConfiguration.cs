using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(500);

            builder.Property(e => e.CustomerName).HasMaxLength(250);

            builder.Property(e => e.PhoneNumber).HasMaxLength(150);

            builder.HasOne(e => e.RefOrderType)
                .WithMany(e => e.Order)
                .HasForeignKey(e => e.OrderTypeId)
                .HasConstraintName("FK_Order_RefOrderType");

            builder.HasOne(e => e.RefCurrency)
                .WithMany(e => e.Order)
                .HasForeignKey(e => e.CurrencyId)
                .HasConstraintName("FK_Order_RefCurrency");

            builder.Property(e => e.Total).HasPrecision(18, 2);

            builder.Property(e => e.ConvertedTotal).HasPrecision(18, 2);
        }
    }
}
