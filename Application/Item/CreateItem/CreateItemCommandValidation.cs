using Domain.Interfaces.Product;
using FluentValidation;

namespace EcommerceShop.Application.Item.CreateItem
{
    public class CreateItemCommandValidation : AbstractValidator<CreateItemCommand>
    {
        private readonly IProductItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        public CreateItemCommandValidation(IProductItemRepository itemRepository, IProductRepository productRepository, IColorRepository colorRepository, ISizeRepository sizeRepository)
        {
            itemRepository = _itemRepository;
            productRepository = _productRepository;
            colorRepository = _colorRepository;
            sizeRepository = _sizeRepository;

            RuleFor(i => i.ProductId)
                .Custom((value, context) =>
                {
                    var product = _productRepository.GetById(value);
                    if (product == null)
                    {
                        context.AddFailure("Product does not exist");
                    }
                });

            RuleFor(i => i.ColorId)
                  .Custom((value, context) =>
                  {
                      var color = _colorRepository.GetById(value);
                      if (color != null)
                      {
                          context.AddFailure("Color does not exist");
                      }
                  });

            RuleFor(i => i.SizeId)
                  .Custom((value, context) =>
                  {
                      var size = _sizeRepository.GetById(value);
                      if (size != null)
                      {
                          context.AddFailure("Size does not exist");
                      }
                  });

            RuleFor(i => i.SKU)
                .Custom((value, context) =>
                {
                    var sku = _itemRepository.GetBySku(value);

                    if (sku != null)
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
