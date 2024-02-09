using EcommerceShop.Application.Item.CreateItem;
using MediatR;

namespace EcommerceShop.Application.Item.GetAllItems
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}