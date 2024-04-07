using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Product
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public ProductRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();

        public async Task Create(EcommerceShop.Domain.Entities.Product.Product product)
        {
            _dbContext.Add(product);
            await Commit();
        }

        public async Task Delete(EcommerceShop.Domain.Entities.Product.Product product)
        {
            var itemsToRemove = _dbContext.ProductItems.Where(i => i.ProductId == product.Id).ToList();

            _dbContext.ProductItems.RemoveRange(itemsToRemove);
            _dbContext.Products.Remove(product);

            await Commit();
        }

        public async Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetAll()
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetByCategory(int categoryId)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<EcommerceShop.Domain.Entities.Product.Product?> GetById(int id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
