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

        public static IRuleBuilderOptions<T, int?> NotNullOrEmpty<T>(
            this IRuleBuilder<T, int?> ruleBuilder, string fieldName)
        {
            string error = $"The field {fieldName} is required";
            return ruleBuilder
                .NotNull().WithMessage(error)
                .NotEqual(0).WithMessage(error);
        }

        public static IRuleBuilderOptions<T, string> HasMaxLength<T>(
            this IRuleBuilder<T, string> ruleBuilder, string fieldName, int maxChars)
        {
            return ruleBuilder
                .MaximumLength(maxChars)
                .WithMessage($"The field {fieldName} cannot exceed {maxChars} characters");
        }
    }
}
