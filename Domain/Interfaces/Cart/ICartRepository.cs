using EcommerceShop.Domain.Entities.Cart;

namespace Domain.Interfaces.Cart
{
    public interface ICartRepository
    {
        Task Create(EcommerceShop.Domain.Entities.Cart.Cart cart);
        Task<IEnumerable<EcommerceShop.Domain.Entities.Cart.Cart>> GetByUser(string userId);
        Task Clear(EcommerceShop.Domain.Entities.Cart.Cart cart);
    }
}
