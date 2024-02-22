using Application.Category.CreateCategory;
using Domain.Interfaces;
using FluentValidation;

namespace EcommerceShop.Application.Category.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(ICategoryRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(40).WithMessage("Name should have maxium of 10 characters")
                .Custom((value, context) =>
                {
                    var existingCategory = repository.GetByName(value).Result;
                    if (existingCategory != null)
                    {
                        context.AddFailure($"{value} is not unique name for carategory");
                    }
                });
        }
    }
}
