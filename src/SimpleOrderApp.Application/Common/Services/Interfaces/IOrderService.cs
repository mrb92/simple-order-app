using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderDetail.Dtos;

namespace SimpleOrderApp.Application.Common.Services.Interfaces
{
    public interface IOrderService
    {
        Task<int> Create(CreateOrderDto createOrderDto, CancellationToken token);

        Task<GetOrderDetailDto> GetOrderDetail(int orderId, CancellationToken token);
    }
}
