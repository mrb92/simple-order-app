using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using SimpleOrderApp.Application.OrderTypes.Services;
using SimpleOrderApp.Domain.Enums.Orders;

namespace SimpleOrderApp.Application.OrderTypes.Common.Services
{
    //<inheritdoc/>
    public class OrderHandlersService : IOrderHandlersService
    {
        private readonly IVehicleOrderService _vehicleOrderService;

        private readonly Dictionary<OrderTypeEnum, Func<int, CancellationToken, Task<GetOrderDetailDto>>>
            _orderDetailHandlerMap = new();

        private readonly Dictionary<OrderTypeEnum, Func<CreateOrderDto, CancellationToken, Task<int>>>
            _orderCreationHandlerMap = new();

        public OrderHandlersService(IVehicleOrderService vehicleOrderService)
        {
            _vehicleOrderService = vehicleOrderService;

            Init();
        }

        private void Init()
        {
            _orderDetailHandlerMap.Add(OrderTypeEnum.Vehicles, _vehicleOrderService.GetOrderDetail);
            _orderCreationHandlerMap.Add(OrderTypeEnum.Vehicles, _vehicleOrderService.Create);
        }

        //<inheritdoc/>
        public Func<int, CancellationToken, Task<GetOrderDetailDto>> GetOrderDetailHandler(int orderTypeId)
        {
            return _orderDetailHandlerMap[(OrderTypeEnum)orderTypeId];
        }

        //<inheritdoc/>
        public Func<CreateOrderDto, CancellationToken, Task<int>> GetOrderCreationHandler(int orderTypeId)
        {
            return _orderCreationHandlerMap[(OrderTypeEnum)orderTypeId];
        }
    }
}
