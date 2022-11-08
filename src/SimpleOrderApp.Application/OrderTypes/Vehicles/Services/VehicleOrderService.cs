using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.NewOrder.Services.Interfaces;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using SimpleOrderApp.Application.OrderDetail.Queries.GetVehicleOrderDetail;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Enums.Orders;

namespace SimpleOrderApp.Application.OrderTypes.Services
{
    public class VehicleOrderService : IVehicleOrderService
    {
        private readonly IApplicationDbContext _context;
        private readonly ICreateOrderCommonService _createOrderCommonService;

        public VehicleOrderService(ICreateOrderCommonService createOrderCommonService,
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

        public async Task<GetOrderDetailDto> GetOrderDetail(int orderId, CancellationToken token)
        {
            var order = await _context.ReadSet<Order>()
                .Include(o => o.VehicleOrder).Where(o => o.Id == orderId).FirstOrDefaultAsync(token);

            return new GetVehicleOrderDetailDto
            {
                Id = order.Id,
                Title = order.Title,
                IsTankFull = order.VehicleOrder.IsTankFull,
                IsCarIntact = order.VehicleOrder.IsCarIntact,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                Total = order.Total,
                PricePerDay = order.VehicleOrder.PricePerDay
            };
        }
    }
}
