using Microsoft.AspNetCore.Mvc;
using SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters;
using SimpleOrderApp.Application.Vehicles.Queries.GetVehicleFilters;
using SimpleOrderApp.Application.Vehicles.Queries.GetVehicles;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class VehiclesController : BaseApiController
    {
        [HttpGet("vehicle-filters")]
        public async Task<GetVehicleFiltersDto> GetVehicleFilters([FromQuery] GetVehicleFiltersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("vehicles")]
        public async Task<GetVehiclesDto> GetVehicles([FromQuery] GetVehiclesQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
