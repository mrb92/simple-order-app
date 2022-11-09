using FluentValidation;
using SimpleOrderApp.Common.Extensions;

namespace SimpleOrderApp.Application.NewOrder.Commands.Create
{
    /// <summary>
    /// Create Order Command Validator
    /// </summary>
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        ///
        public CreateOrderCommandValidator()
        {
            RuleFor(v => v.CustomerName)
                .NotNullOrEmpty("Customer Name");

            RuleFor(v => v.CustomerPhone)
                .NotNullOrEmpty("Customer Phone");
        }
    }
}
