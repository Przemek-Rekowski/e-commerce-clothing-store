using MediatR;

namespace EcommerceShop.Application.Item.CreateItem
{
    public class CreateItemCommand : ItemDto, IRequest<Unit>
    {
    }
}