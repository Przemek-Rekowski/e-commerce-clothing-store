using EcommerceShop.Domain.Entities.Cart;

namespace Domain.Interfaces.Cart
{
    public interface ICartItemRepository
    {
        Task Create(CartItem item);
        Task<CartItem?> GetById(int id);
        Task Delete(CartItem item);
        Task Commit();
    }
}
