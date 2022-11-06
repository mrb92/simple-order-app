using SimpleOrderApp.Domain.Dtos.Common;

namespace SimpleOrderApp.Application.Vehicles.Queries
{
    public class GetVehicleFiltersDto
    {
        public List<KeyValueDto> VehicleTypes { get; set; }
    }
}
