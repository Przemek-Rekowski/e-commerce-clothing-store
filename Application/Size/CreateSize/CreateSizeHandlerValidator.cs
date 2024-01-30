using Application.Size.CreateSize;
using FluentValidation;

namespace EcommerceShop.Application.Size.CreateSize
{
    public class CreateSizeCommandValidator : AbstractValidator<CreateSizeCommand>
    {
        public CreateSizeCommandValidator()
        {
            RuleFor(i => i.Size)
                .NotEmpty();

            RuleFor(i => i.Quantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
