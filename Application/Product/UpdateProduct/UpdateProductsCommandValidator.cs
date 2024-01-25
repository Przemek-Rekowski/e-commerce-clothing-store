using FluentValidation;

namespace EcommerceShop.Application.Product.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(40).WithMessage("Name should have maxium of 40 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.Price)
                .GreaterThan(0);
        }
    }
}
