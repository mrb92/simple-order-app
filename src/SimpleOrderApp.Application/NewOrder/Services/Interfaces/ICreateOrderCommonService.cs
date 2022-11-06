using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.NewOrder.Services.Interfaces
{
    public interface ICreateOrderCommonService
    {
        Order Create(CreateOrderDto createOrderDto, int orderTypeId);
    }
}
