using MediatR;

using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.OrderDetail.Command.UpdateVehicleOrder
{
    public class UpdateVehicleOrderCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsTankFull { get; set; }

        public bool IsCarIntact { get; set; }

        public decimal AdditionalCost { get; set; }
    }

    public class UpdateVehicleOrderCommandHandler : IRequestHandler<UpdateVehicleOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVehicleOrderCommand request, CancellationToken token)
        {
            var order = await _context.Set<Order>().Include(o => o.VehicleOrder).FirstOrDefaultAsync(token);

            order.EndDate = request.EndDate;
            order.VehicleOrder.IsCarIntact = request.IsCarIntact;
            order.VehicleOrder.IsTankFull = request.IsTankFull;

            var numberOfDays = (request.EndDate - order.StartDate).Days;
            order.Total = order.VehicleOrder.PricePerDay * numberOfDays;

            if (request.AdditionalCost > 0)
                order.Total += request.AdditionalCost;

            await _context.SaveChangesExAsync(token);

            return Unit.Value;
        }
    }
}
