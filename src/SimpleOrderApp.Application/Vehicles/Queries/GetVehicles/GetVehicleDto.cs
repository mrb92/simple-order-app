namespace SimpleOrderApp.Application.Vehicles.Queries.GetVehicles
{
    public class GetVehicleDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int TypeId { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
