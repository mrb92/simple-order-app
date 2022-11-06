using MediatR;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using SimpleOrderApp.Application.OrderTypes.Common.Services;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<GetOrderDetailDto>
    {
        public int Id { get; set; }

        public int OrderTypeId { get; set; }
    }

    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, GetOrderDetailDto>
    {
        private readonly IOrderHandlersService _orderHandlersService;

        public GetOrderDetailQueryHandler(IOrderHandlersService orderHandlersService)
        {
            _orderHandlersService = orderHandlersService;
        }

        public async Task<GetOrderDetailDto> Handle(GetOrderDetailQuery request, CancellationToken token)
        {
            var handler = _orderHandlersService.GetOrderDetailHandler(request.OrderTypeId);

            return await handler(request.Id, token);
        }
    }

}
