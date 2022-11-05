using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public decimal? Total { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? ConvertedTotal { get; set; }

        public int OrderTypeId { get; set; }

        public RefOrderType RefOrderType { get; set; }

        public RefCurrency RefCurrency { get; set; }

        public VehicleOrder VehicleOrder { get; set; }
    }
}
