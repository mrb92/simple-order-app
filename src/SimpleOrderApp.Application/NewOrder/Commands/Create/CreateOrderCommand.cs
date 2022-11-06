using MediatR;

using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderTypes.Common.Services;

namespace SimpleOrderApp.Application.NewOrder.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime StartDate { get; set; }

        public int OrderTypeId { get; set; }

        public int ItemId { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderHandlersService _orderHandlersService;

        public CreateOrderCommandHandler(IOrderHandlersService orderHandlersService)
        {
            _orderHandlersService = orderHandlersService;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken token)
        {
            var handler = _orderHandlersService.GetOrderCreationHandler(request.OrderTypeId);

            var input = new CreateOrderDto
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                ItemId = request.ItemId,
                StartDate = request.StartDate
            };

            return await handler(input, token);
        }
    }
}
