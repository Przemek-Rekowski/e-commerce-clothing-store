using EcommerceShop.Application.CartItem.Dtos;
using MediatR;

namespace EcommerceShop.Application.CartItem.UpdateCartItem
{
    public class UpdateCartItemCommand : CartItemDto, IRequest<Unit>
    {
        public int Id;

        public UpdateCartItemCommand(int id)
        {
            Id = id;
        }
    }
}
