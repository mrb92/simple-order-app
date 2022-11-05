using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations.Referentials
{
    public class RefOrderTypeConfiguration : IEntityTypeConfiguration<RefOrderType>
    {
        public void Configure(EntityTypeBuilder<RefOrderType> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(200);
        }
    }
}
