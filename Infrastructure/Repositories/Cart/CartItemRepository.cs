using Domain.Interfaces.Cart;
using EcommerceShop.Domain.Entities.Cart;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cart
{
    internal class CartItemRepository : ICartItemRepository
    {
        private readonly EcommerceShopDbContext _dbContext;
        public CartItemRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
             => _dbContext.SaveChangesAsync();

        public async Task Create(CartItem item)
        {
            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(CartItem item)
        {
            _dbContext.CartItems.Remove(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<CartItem?> GetById(int id)
            => await _dbContext.CartItems.FirstOrDefaultAsync(ci => ci.Id == id);
    }
}
