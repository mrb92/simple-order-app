using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Dtos.Common;
using SimpleOrderApp.Domain.Entities.Referentials;

namespace SimpleOrderApp.Application.Common.Queries.GetOrderTypes
{
    /// <summary>
    /// Get Order Types Query
    /// </summary>
    public class GetOrderTypesQuery : IRequest<List<KeyValueDto>>
    {
    }

    /// <summary>
    /// Get Order Types Query Handler
    /// </summary>
    public class GetOrderTypesQueryHandler : IRequestHandler<GetOrderTypesQuery, List<KeyValueDto>>
    {
        private IApplicationDbContext _context;

        ///
        public GetOrderTypesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        ///
        public async Task<List<KeyValueDto>> Handle(GetOrderTypesQuery request, CancellationToken token)
        {
            var orderTypes = await _context.ReadSet<RefOrderType>().ToListAsync(token);

            return CreateVehicleDtos(orderTypes);
        }

        private List<KeyValueDto> CreateVehicleDtos(List<RefOrderType> orderTypes)
        {
            return orderTypes.Select(v => new KeyValueDto
            {
                Key = v.Id,
                Value = v.Name
            }).ToList();
        }
    }
}
