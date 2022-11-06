using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.NewOrder.Services.Interfaces;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Enums.Orders;

namespace SimpleOrderApp.Application.NewOrder.Services
{
    public class CreateVehicleOrderService : ICreateVehicleOrderService
    {
        private IApplicationDbContext _context;
        private ICreateOrderCommonService _createOrderCommonService;

        public CreateVehicleOrderService(ICreateOrderCommonService createOrderCommonService,
            IApplicationDbContext context)
        {
            _createOrderCommonService = createOrderCommonService;
            _context = context;
        }

        public async Task<int> Create(CreateOrderDto createOrderDto, CancellationToken token)
        {
            var orderTypeId = (int)OrderTypeEnum.Vehicles;

            var order = _createOrderCommonService.Create(createOrderDto, orderTypeId);

            var vehicle = await _context.ReadSet<Vehicle>().FirstOrDefaultAsync(v => v.Id == createOrderDto.ItemId, token);

            order.Title = $"{vehicle.Make} {vehicle.Model}";

            order.VehicleOrder = new VehicleOrder
            {
                VehicleId = vehicle.Id,
                PricePerDay = vehicle.PricePerDay
            };

            await _context.Set<Order>().AddAsync(order, token);

            await _context.SaveChangesExAsync(token);

            return order.Id;
        }
    }
}
