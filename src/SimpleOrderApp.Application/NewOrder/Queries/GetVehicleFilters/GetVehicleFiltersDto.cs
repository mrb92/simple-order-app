using SimpleOrderApp.Domain.Dtos.Common;

namespace SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters
{
    public class GetVehicleFiltersDto
    {
        public List<KeyValueDto> VehicleTypes { get; set; }
    }
}
