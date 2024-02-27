using FluentValidation;
using Infrastructure.Persistence;

namespace EcommerceShop.Application.Item.CreateItem
{
    public class CreateItemCommandValidation : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidation(EcommerceShopDbContext dbContext)
        {
            RuleFor(i => i.ProductId)
                .Custom((value, context) =>
                {
                    var productExist = dbContext.Products.Any(p => p.Id == value);
                    if (!productExist)
                    {
                        context.AddFailure("Product does not exist");
                    }
                });

            RuleFor(i => i.ColorId)
                  .Custom((value, context) =>
                  {
                      var colorExist = dbContext.Colors.Any(c => c.Id == value);
                      if (!colorExist)
                      {
                          context.AddFailure("Color does not exist");
                      }
                  });

            RuleFor(i => i.SizeId)
                  .Custom((value, context) =>
                  {
                      var sizeExist = dbContext.Sizes.Any(s => s.Id == value);
                      if (!sizeExist)
                      {
                          context.AddFailure("Size does not exist");
                      }
                  });

            RuleFor(i => i.SKU)
                .Custom((value, context) =>
                {
                    var skuExist = dbContext.Items.Any(i => i.SKU.Equals(value));
                    if (skuExist)
                    {
                        context.AddFailure("Item already exists");
                    }
                });

            RuleFor(dto => dto.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity should be greater than or equal to 0.");

            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price should be greater than or equal to 0.");
        }
    }
}
