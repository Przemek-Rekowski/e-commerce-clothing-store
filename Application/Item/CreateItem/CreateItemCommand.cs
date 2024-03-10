using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.CreateItem
{
    public class CreateItemCommand : CreateItemDto, IRequest<Unit>
    {
    }
}