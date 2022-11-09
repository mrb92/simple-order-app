using MediatR;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using SimpleOrderApp.Application.OrderTypes.Common.Services;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetOrderDetail
{
    /// <summary>
    /// Get Order Detail Query
    /// </summary>
    public class GetOrderDetailQuery : IRequest<GetOrderDetailDto>
    {
        ///
        public int Id { get; set; }

        ///
        public int OrderTypeId { get; set; }
    }

    /// <summary>
    /// Get Order Detail Query Handler
    /// </summary>
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, GetOrderDetailDto>
    {
        private readonly IOrderHandlersService _orderHandlersService;

        ///
        public GetOrderDetailQueryHandler(IOrderHandlersService orderHandlersService)
        {
            _orderHandlersService = orderHandlersService;
        }

        ///
        public async Task<GetOrderDetailDto> Handle(GetOrderDetailQuery request, CancellationToken token)
        {
            var handler = _orderHandlersService.GetOrderDetailHandler(request.OrderTypeId);

            return await handler(request.Id, token);
        }
    }

}
