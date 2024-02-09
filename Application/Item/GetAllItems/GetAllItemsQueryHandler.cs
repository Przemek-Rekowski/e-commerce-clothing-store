using AutoMapper;
using Domain.Interfaces;
using EcommerceShop.Application.Item.CreateItem;
using MediatR;

namespace EcommerceShop.Application.Item.GetAllItems
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
    {
        private readonly IProductItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetAllItemsQueryHandler(IProductItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ItemDto>>(items);


            return dtos;
        }
    }
}