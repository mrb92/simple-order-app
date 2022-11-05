using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations
{
    public class VehicleOrderConfiguration : IEntityTypeConfiguration<VehicleOrder>
    {
        public void Configure(EntityTypeBuilder<VehicleOrder> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(e => e.Order)
                .WithOne(e => e.VehicleOrder)
                .HasForeignKey<VehicleOrder>(e => e.Id)
                .HasConstraintName("FK_VehicleOrder_Order")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Vehicle)
                .WithMany(e => e.VehicleOrders)
                .HasForeignKey(e => e.VehicleId)
                .HasConstraintName("FK_VehicleOrder_Vehicle");

            builder.Property(e => e.PricePerDay).HasPrecision(18, 2);

            builder.Property(e => e.ConvertedPricePerDay).HasPrecision(18, 2);
        }
    }
}
