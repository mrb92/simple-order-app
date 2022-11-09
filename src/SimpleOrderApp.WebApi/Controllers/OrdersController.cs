using Microsoft.AspNetCore.Mvc;

using SimpleOrderApp.Application.Common.Queries.GetOrderTypes;
using SimpleOrderApp.Application.ListOrder.Queries.GetOrders;
using SimpleOrderApp.Application.NewOrder.Commands.Create;
using SimpleOrderApp.Application.OrderDetail.Command.UpdateVehicleOrder;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using SimpleOrderApp.Application.OrderDetail.Queries.GetOrderDetail;
using SimpleOrderApp.Domain.Dtos.Common;
using SimpleOrderApp.WebApi.Base;

namespace SimpleOrderApp.WebApi.Controllers
{
    /// <summary>
    /// Orders Controller
    /// </summary>
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

        [HttpPut("vehicle-order")]
        public async Task UpdateOrder(UpdateVehicleOrderCommand command,
            CancellationToken token)
        {
            await Mediator.Send(command, token);
        }


        [HttpGet("{id}")]
        public async Task<GetOrderDetailDto> GetOrderDetail(int id, int orderTypeId, CancellationToken token)
        {
            var query = new GetOrderDetailQuery { Id = id, OrderTypeId = orderTypeId };

            return await Mediator.Send(query);
        }

    }
}
