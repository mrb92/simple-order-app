namespace SimpleOrderApp.Domain.Entities
{
    public class VehicleOrder
    {
        public int Id { get; set; }

        public bool? IsTankFull { get; set; }

        public bool? IsCarIntact { get; set; }

        public int VehicleId { get; set; }

        public decimal PricePerDay { get; set; }

        public decimal? PriceInForeignCurrencyPerDay { get; set; }

        public Vehicle Vehicle { get;set; }

        public Order Order { get; set; }
    }
}
