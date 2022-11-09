using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters;
using SimpleOrderApp.Application.Vehicles.Queries.GetVehicleFilters;
using SimpleOrderApp.Application.Vehicles.Queries.GetVehicles;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    /// <summary>
    /// Vehicles Controller
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/vehicles")]
    public class VehiclesController : BaseApiController
    {
        [HttpGet("filters")]
        public async Task<GetVehicleFiltersDto> GetVehicleFilters([FromQuery] GetVehicleFiltersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<GetVehiclesDto> GetVehicles([FromQuery] GetVehiclesQuery query)
        {
            return await Mediator.Send(query);
        }

    }
}
