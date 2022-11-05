using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations.Referentials
{
    public class RefCurrencyConfiguration : IEntityTypeConfiguration<RefCurrency>
    {
        public void Configure(EntityTypeBuilder<RefCurrency> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(150);

            builder.Property(e => e.ShortName).HasMaxLength(150);

            builder.Property(e => e.Symbol).HasMaxLength(5);
        }
    }
}
