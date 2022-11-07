using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations
{
    public class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.HasOne(e => e.FromCurrency)
                .WithMany(e => e.CurrencyRateFrom)
                .HasForeignKey(e => e.FromCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CurrencyRate_RefCurrency_From");

            builder.HasOne(e => e.ToCurrency)
                .WithMany(e => e.CurrencyRateTo)
                .HasForeignKey(e => e.ToCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CurrencyRate_RefCurrency_To");

            builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        }
    }
}
