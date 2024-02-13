using Application.Product.CreateProduct;
using Domain.Interfaces;
using FluentValidation;

namespace EcommerceShop.Application.Product.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(40).WithMessage("Name should have maxium of 40 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");
        }
    }
}
