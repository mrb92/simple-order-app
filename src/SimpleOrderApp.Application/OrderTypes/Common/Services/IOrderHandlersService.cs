using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderDetail.Dtos;

namespace SimpleOrderApp.Application.OrderTypes.Common.Services
{
    /// <summary>
    /// Order Handlers
    /// </summary>
    public interface IOrderHandlersService
    {
        /// <summary>
        /// Order Handler for order detail
        /// </summary>
        /// <param name="orderTypeId"></param>
        /// <returns></returns>
        Func<int, CancellationToken, Task<GetOrderDetailDto>> GetOrderDetailHandler(int orderTypeId);

        /// <summary>
        /// Order creation handlers
        /// </summary>
        /// <param name="orderTypeId"></param>
        /// <returns></returns>
        Func<CreateOrderDto, CancellationToken, Task<int>> GetOrderCreationHandler(int orderTypeId);
    }
}
