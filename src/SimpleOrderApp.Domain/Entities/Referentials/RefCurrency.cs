namespace SimpleOrderApp.Domain.Entities.Referentials
{
    public class RefCurrency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Symbol { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRateFrom { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRateTo { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
