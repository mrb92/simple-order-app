using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.NewOrder.Services.Interfaces
{
    /// <summary>
    /// Service for common order creation tasks
    /// </summary>
    public interface ICreateOrderCommonService
    {
        /// <summary>
        /// Creates an order entity
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <param name="orderTypeId"></param>
        /// <returns></returns>
        Order Create(CreateOrderDto createOrderDto, int orderTypeId);
    }
}
