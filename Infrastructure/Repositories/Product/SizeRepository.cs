using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Product
{
    internal class SizeRepository : ISizeRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public SizeRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task GetById(int id)
            => await _dbContext.Colors.FirstOrDefaultAsync(s => s.Id == id);
    }
}
