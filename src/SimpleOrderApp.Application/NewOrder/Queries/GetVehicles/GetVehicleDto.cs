namespace SimpleOrderApp.Application.Vehicles.Queries.GetVehicles
{
    /// <summary>
    /// Represents a single vehicle
    /// </summary>
    public class GetVehicleDto
    {
        ///
        public int Id { get; set; }

        ///
        public string Make { get; set; }

        ///
        public string Model { get; set; }

        /// <summary>
        /// Vehicle Type
        /// </summary>
        public int TypeId { get; set; }

        ///
        public decimal PricePerDay { get; set; }
    }
}
