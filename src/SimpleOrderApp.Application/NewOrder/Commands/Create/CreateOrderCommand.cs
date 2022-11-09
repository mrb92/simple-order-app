using MediatR;

using SimpleOrderApp.Application.NewOrder.Dtos;
using SimpleOrderApp.Application.OrderTypes.Common.Services;

namespace SimpleOrderApp.Application.NewOrder.Commands.Create
{
    /// <summary>
    /// Create Order Command
    /// </summary>
    public class CreateOrderCommand : IRequest<int>
    {
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer Phone
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Oder Type Id
        /// </summary>
        public int OrderTypeId { get; set; }

        /// <summary>
        /// Item Id
        /// </summary>
        public int ItemId { get; set; }
    }

    /// <summary>
    /// Create Order Command Handler
    /// </summary>
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderHandlersService _orderHandlersService;

        ///
        public CreateOrderCommandHandler(IOrderHandlersService orderHandlersService)
        {
            _orderHandlersService = orderHandlersService;
        }

        ///
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
