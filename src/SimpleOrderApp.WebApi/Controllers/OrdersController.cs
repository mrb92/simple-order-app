using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.Orders.Queries.GetOrders;
using SimpleOrderApp.Application.Orders.Queries.GetOrderTypes;
using SimpleOrderApp.Domain.Dtos.Common;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class OrdersController : BaseApiController
    {
        [HttpGet("order-types")]
        public async Task<List<KeyValueDto>> GetOrderTypes([FromQuery] GetOrderTypesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("orders")]
        public async Task<GetOrdersDto> GetOrders([FromQuery] GetOrdersQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
