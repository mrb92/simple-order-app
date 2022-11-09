using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderDetail.Dtos;

namespace SimpleOrderApp.Application.Common.Services.Interfaces
{
    /// <summary>
    /// Order Service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<int> Create(CreateOrderDto createOrderDto, CancellationToken token);

        /// <summary>
        /// Gets the details of an order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<GetOrderDetailDto> GetOrderDetail(int orderId, CancellationToken token);
    }
}
