using EcommerceShop.Application.CartItem.Dtos;
using MediatR;

namespace EcommerceShop.Application.CartItem.CreateCartItem
{
    public class CreateCartItemCommand : CreateCartItemDto, IRequest<Unit>
    {
    }
}