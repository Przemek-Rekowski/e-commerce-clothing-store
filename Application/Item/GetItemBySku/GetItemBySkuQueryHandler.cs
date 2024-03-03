using AutoMapper;
using Domain.Interfaces.Product;
using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.GetItemBySku
{
    public class GetItemBySkuQueryHandler : IRequestHandler<GetItemBySkuQuery, ItemDto>
    {
        private readonly IProductItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemBySkuQueryHandler(IProductItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ItemDto> Handle(GetItemBySkuQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetBySku(request.SKU);

            var dto = _mapper.Map<ItemDto>(item);

            return dto;
        }
    }
}