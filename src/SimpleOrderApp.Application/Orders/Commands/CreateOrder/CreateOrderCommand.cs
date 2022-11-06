using MediatR;
using SimpleOrderApp.Application.Common.Interfaces;

namespace SimpleOrderApp.Application.Orders.Commands.CreateOrder
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
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken token)
        {
            return 0;
        }
    }
}
