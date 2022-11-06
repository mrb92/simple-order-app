using SimpleOrderApp.Application.Orders.Dtos;
using SimpleOrderApp.Application.Orders.Services.Interfaces;
using SimpleOrderApp.Domain.Enums.Orders;

namespace SimpleOrderApp.Application.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly Dictionary<
            OrderTypeEnum,
            Func<CreateOrderDto, CancellationToken, Task<int>>>
            _orderCreatorHandlerMap = new();



        public OrderService()
        {

        }
    }
}
