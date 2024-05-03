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

        public async Task<(IEnumerable<ProductItem>, int)> GetAll(string? searchPhrase, int pageSize, int pageNumber)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _dbContext.ProductItems
                .Include(pi => pi.Product)
                    .ThenInclude(pi => pi.Category)
                .Include(pi => pi.Size)
                .Include(pi => pi.Color)
                .Include(pi => pi.Images)
                .Where(pi => searchPhraseLower == null || (pi.Product.Name.ToLower().Contains(searchPhraseLower)
                                                       || pi.Product.Description.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();

            var items = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
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
