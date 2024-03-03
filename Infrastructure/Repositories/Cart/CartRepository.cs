using Domain.Interfaces.Cart;

namespace Infrastructure.Repositories.Cart
{
    internal class CartRepository : ICartRepository
    {
        public Task Clear(EcommerceShop.Domain.Entities.Cart.Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task Create(EcommerceShop.Domain.Entities.Cart.Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EcommerceShop.Domain.Entities.Cart.Cart>> GetByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
