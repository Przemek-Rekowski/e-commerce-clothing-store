using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.GetAllItems
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}