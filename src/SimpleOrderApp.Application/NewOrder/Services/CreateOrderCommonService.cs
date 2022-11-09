using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.NewOrder.Services.Interfaces;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.NewOrder.Services
{
    //<inheritdoc/>
    public class CreateOrderCommonService : ICreateOrderCommonService
    {
        //<inheritdoc/>
        public Order Create(CreateOrderDto createOrderDto, int orderTypeId)
        {
            var order = new Order
            {
                CustomerName = createOrderDto.CustomerName,
                CustomerPhoneNumber = createOrderDto.CustomerPhone,
                OrderTypeId = orderTypeId,
                StartDate = createOrderDto.StartDate
            };

            return order;
        }
    }
}
