namespace SimpleOrderApp.Application.Vehicles.Queries.GetVehicles
{
    /// <summary>
    /// Represents a get vehicles query result
    /// </summary>
    public class GetVehiclesDto
    {
        /// <summary>
        /// List of available vehicles
        /// </summary>
        public List<GetVehicleDto> Vehicles { get; set; } = new();
    }
}
