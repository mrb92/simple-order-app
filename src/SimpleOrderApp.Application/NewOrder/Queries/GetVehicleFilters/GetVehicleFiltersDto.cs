using SimpleOrderApp.Domain.Dtos.Common;

namespace SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters
{
    /// <summary>
    /// Vehicle Filters 
    /// </summary>
    public class GetVehicleFiltersDto
    {
        /// <summary>
        /// List of Vehicle Types
        /// </summary>
        public List<KeyValueDto> VehicleTypes { get; set; }
    }
}
