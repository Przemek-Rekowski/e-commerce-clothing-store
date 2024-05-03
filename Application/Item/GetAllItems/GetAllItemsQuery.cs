using Domain.Constants;
using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.GetAllItems
{
    public class GetAllItemsQuery : IRequest<PagedResult<ItemDto>>
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}