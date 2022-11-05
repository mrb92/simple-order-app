using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations.Referentials
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(e => e.Make).HasMaxLength(200);

            builder.Property(e => e.Model).HasMaxLength(300);

            builder.HasOne(e => e.RefVehicleType)
                .WithMany(e => e.Vehicle)
                .HasForeignKey(e => e.TypeId)
                .HasConstraintName("FK_Vehicle_RefVehicle")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.PricePerDay).HasPrecision(18, 2);
        }
    }
}
