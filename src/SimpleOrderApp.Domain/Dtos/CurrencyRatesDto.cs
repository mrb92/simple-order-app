namespace SimpleOrderApp.Domain.Dtos
{
    public class CurrencyRatesDto
    {
        public Dictionary<string, decimal> Quotes { get; set; }

        public string Source { get; set; }

        public bool Success { get; set; }

        public int Timestamp { get; set; }
    }
}
