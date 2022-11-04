using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.Orders.Queries.GetOrders;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class OrdersController : BaseApiController
    {
        [HttpGet("orders")]
        public async Task<GetOrdersDto> GetOrders([FromQuery] GetOrdersQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
