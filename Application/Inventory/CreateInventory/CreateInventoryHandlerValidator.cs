using Application.Inventory.CreateInventory;
using FluentValidation;

namespace EcommerceShop.Application.Inventory.CreateInventory
{
    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryCommandValidator()
        {
            RuleFor(i => i.Size)
                .NotEmpty();

            RuleFor(i => i.Quantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
