using FluentValidation;

namespace SimpleOrderApp.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNullOrEmpty<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, string fieldName)
        {
            string error = $"The field {fieldName} is required";
            return ruleBuilder
                .NotEmpty().WithMessage(error)
                .NotNull().WithMessage(error);
        }
    }
}
