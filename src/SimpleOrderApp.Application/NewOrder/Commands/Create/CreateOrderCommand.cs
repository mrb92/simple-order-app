using MediatR;

using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.NewOrder.Services.Interfaces;
using SimpleOrderApp.Domain.Enums.Orders;

namespace SimpleOrderApp.Application.NewOrder.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime StartDate { get; set; }

        public int OrderTypeId { get; set; }

        public int ItemId { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly Dictionary<OrderTypeEnum, Func<CreateOrderDto, CancellationToken, Task<int>>>
            _orderCreatorHandlerMap = new();

        private readonly ICreateVehicleOrderService _createVehicleOrderService;

        public CreateOrderCommandHandler(ICreateVehicleOrderService createVehicleOrderService)
        {
            _createVehicleOrderService = createVehicleOrderService;

            Init();
        }

        private void Init()
        {
            _orderCreatorHandlerMap.Add(OrderTypeEnum.Vehicles, _createVehicleOrderService.Create);
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken token)
        {
            var handler = _orderCreatorHandlerMap[(OrderTypeEnum)request.OrderTypeId];

            var input = new CreateOrderDto
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                ItemId = request.ItemId,
                StartDate = request.StartDate
            };

            return await handler(input, token);
        }
    }
}
