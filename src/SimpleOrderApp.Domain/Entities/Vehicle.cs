using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int TypeId { get; set; }

        public decimal PricePerDay { get; set; }

        public RefVehicleType RefVehicleType { get; set; }

        public List<VehicleOrder> VehicleOrders { get; set; }
    }
}
