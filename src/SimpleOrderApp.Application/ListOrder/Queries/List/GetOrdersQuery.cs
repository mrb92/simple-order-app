using MediatR;
using Microsoft.EntityFrameworkCore;

using SimpleOrderApp.Application.Common.Interfaces;
using SimpleOrderApp.Domain.Entities;

namespace SimpleOrderApp.Application.ListOrder.Queries.List
{
    public class GetOrdersQuery : IRequest<GetOrdersDto>
    {
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersDto>
    {
        private readonly IApplicationDbContext _context;

        public GetOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrdersDto> Handle(GetOrdersQuery request, CancellationToken token)
        {
            var orders = await _context.ReadSet<Order>().ToListAsync(token);

            return new GetOrdersDto
            {
                Orders = orders.Select(o => new GetOrderDto
                {
                    Id = o.Id,
                    Title = o.Title,
                    CustomerName = o.CustomerName,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    TypeId = o.OrderTypeId
                }).ToList()
            };
        }
    }
}
