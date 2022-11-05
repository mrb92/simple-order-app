using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations.Referentials
{
    public class RefVehicleTypeConfiguration : IEntityTypeConfiguration<RefVehicleType>
    {
        public void Configure(EntityTypeBuilder<RefVehicleType> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(200);
        }
    }
}
