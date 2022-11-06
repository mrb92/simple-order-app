using SimpleOrderApp.Application.NewOrder.Dtos;

namespace SimpleOrderApp.Application.NewOrder.Services.Interfaces
{
    public interface ICreateVehicleOrderService
    {
        Task<int> Create(CreateOrderDto createOrderDto, CancellationToken token);
    }
}
