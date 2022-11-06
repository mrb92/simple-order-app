using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.Common.Queries.GetOrderTypes;
using SimpleOrderApp.Application.ListOrder.Queries.List;
using SimpleOrderApp.Application.NewOrder.Commands.Create;
using SimpleOrderApp.Domain.Dtos.Common;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/orders")]
    public class OrdersController : BaseApiController
    {
        [HttpGet("types")]
        public async Task<List<KeyValueDto>> GetOrderTypes([FromQuery] GetOrderTypesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<GetOrdersDto> GetOrders([FromQuery] GetOrdersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderCommand command,
            CancellationToken token)
        {
            return await Mediator.Send(command, token);
        }
    }
}
