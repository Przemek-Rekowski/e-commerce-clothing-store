using AutoMapper.QueryableExtensions;
using Domain.Interfaces.Product;
using EcommerceShop.Domain.Entities.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Product
{
    internal class ProductItemRepository : IProductItemRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public ProductItemRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();

        public async Task Create(ProductItem product)
        {
            _dbContext.Add(product);
            await Commit();
        }

        public async Task Delete(ProductItem product)
        {
            _dbContext.ProductItems.Remove(product);
            await Commit();
        }

        public async Task<IEnumerable<ProductItem>> GetAll()
        {
            return await _dbContext.ProductItems
                .Include(pi => pi.Product)
                    .ThenInclude(pi => pi.Category)
                .Include(pi => pi.Size)
                .Include(pi => pi.Color)
                .Include(pi => pi.Images)
                .ToListAsync();
        }


        public async Task<ProductItem?> GetBySku(string sku)
        {
            return await _dbContext.ProductItems
                .Include(pi => pi.Product)
                    .ThenInclude(pi => pi.Category)
                .Include(pi => pi.Size)
                .Include(pi => pi.Color)
                .Include(pi => pi.Images)
                .FirstOrDefaultAsync(pi => pi.SKU == sku);
        }
    }
}
