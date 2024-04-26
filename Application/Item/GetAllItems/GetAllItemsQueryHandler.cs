using AutoMapper;
using Domain.Constants;
using Domain.Interfaces.Product;
using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.GetAllItems
{
    public class GetAllItemsQueryHandler(IMapper mapper,
        IProductItemRepository itemRepository) : IRequestHandler<GetAllItemsQuery, PagedResult<ItemDto>>
    {
        public async Task<PagedResult<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await itemRepository.GetAll(request.SearchPhrase,
                request.PageSize,
                request.PageNumber);
            var itemDtos = mapper.Map<IEnumerable<ItemDto>>(items);

            var result = new PagedResult<ItemDto>(itemDtos, totalCount, request.PageSize, request.PageNumber);
            return result;
        }
    }
}