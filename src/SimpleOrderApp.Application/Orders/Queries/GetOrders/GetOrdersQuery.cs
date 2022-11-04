using MediatR;

namespace SimpleOrderApp.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<GetOrdersDto>
    {

    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersDto>
    {
        public async Task<GetOrdersDto> Handle(GetOrdersQuery request, CancellationToken token)
        {
            return new GetOrdersDto
            {
                Name = "something"
            };
        }
    }
}
