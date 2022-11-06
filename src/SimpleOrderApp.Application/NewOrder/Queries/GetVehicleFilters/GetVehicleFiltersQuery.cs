using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters;
using SimpleOrderApp.Domain.Dtos.Common;
using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Application.Vehicles.Queries.GetVehicleFilters
{
    public class GetVehicleFiltersQuery : IRequest<GetVehicleFiltersDto>
    {
    }

    public class GetVehicleFiltersQueryHandler : IRequestHandler<GetVehicleFiltersQuery, GetVehicleFiltersDto>
    {
        private IApplicationDbContext _context;

        public GetVehicleFiltersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetVehicleFiltersDto> Handle(GetVehicleFiltersQuery request, CancellationToken token)
        {
            var vehicleTypes = await _context.ReadSet<RefVehicleType>().ToListAsync(token);

            return new GetVehicleFiltersDto
            {
                VehicleTypes = CreateKeyValueDtos(vehicleTypes)
            };
        }

        private List<KeyValueDto> CreateKeyValueDtos(List<RefVehicleType> vehicleTypes)
        {
            return vehicleTypes.Select(v => new KeyValueDto
            {
                Key = v.Id,
                Value = v.Name
            }).ToList();
        }

    }
}