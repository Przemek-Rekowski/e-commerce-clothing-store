using Application.Item.Dtos;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Product.Application.Product.GetProductById;

namespace Product.Application.Product.Queries.GetProductByEncodedName
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