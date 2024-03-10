using MediatR;

namespace EcommerceShop.Application.CartItem.DeleteCartItem
{
    public class DeleteCartItemCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
        public DeleteCartItemCommand(int id)
        {
            Id = id;
        }
    }
}