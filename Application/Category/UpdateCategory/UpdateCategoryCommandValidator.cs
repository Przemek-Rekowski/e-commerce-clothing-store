using Domain.Interfaces;
using FluentValidation;

namespace EcommerceShop.Application.Category.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator(ICategoryRepository repository)
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
