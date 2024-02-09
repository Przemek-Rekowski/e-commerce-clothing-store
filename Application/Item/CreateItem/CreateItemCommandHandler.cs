using Application.Product.CreateProduct;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace EcommerceShop.Application.Item.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Unit>
    {
        private readonly IProductItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IProductItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Domain.Entities.Product.ProductItem>(request);
            item.GenerateSKU();

            await _itemRepository.Create(item);

            return Unit.Value;
        }
    }
}
