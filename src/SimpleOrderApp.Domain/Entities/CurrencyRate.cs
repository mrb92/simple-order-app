using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Domain.Entities
{
    public class CurrencyRate
    {
        public int Id { get; set; }

        public int FromCurrencyId { get; set; }

        public int ToCurrencyId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public decimal ExchangeRate { get; set; }

        public RefCurrency FromCurrency { get; set; }

        public RefCurrency ToCurrency { get; set; }
    }
}
