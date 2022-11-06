using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.Vehicles.Queries.GetVehicles
{
    public class GetVehiclesQuery : IRequest<GetVehiclesDto>
    {
        public int? TypeId { get; set; }
    }

    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, GetVehiclesDto>
    {
        private IApplicationDbContext _context;

        public GetVehiclesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetVehiclesDto> Handle(GetVehiclesQuery request, CancellationToken token)
        {
            var vehiclesQuery = _context.ReadSet<Vehicle>();

            if (request.TypeId.HasValue)
            {
                vehiclesQuery = vehiclesQuery.Where(v => v.TypeId == request.TypeId);
            }

            var vehicles = await vehiclesQuery.ToListAsync(token);

            return new GetVehiclesDto
            {
                Vehicles = CreateVehicleDtos(vehicles)
            };
        }

        private List<GetVehicleDto> CreateVehicleDtos(List<Vehicle> vehicles)
        {
            return vehicles.Select(v => new GetVehicleDto
            {
                Id = v.Id,
                Make = v.Make,
                Model = v.Model,
                PricePerDay = v.PricePerDay,
                TypeId = v.TypeId
            }).ToList();
        }
    }
}
