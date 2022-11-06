using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderDetail.Dtos;

namespace SimpleOrderApp.Application.OrderTypes.Common.Services
{
    public interface IOrderHandlersService
    {
        Func<int, CancellationToken, Task<GetOrderDetailDto>> GetOrderDetailHandler(int orderTypeId);

        Func<CreateOrderDto, CancellationToken, Task<int>> GetOrderCreationHandler(int orderTypeId);
    }
}
