using Domain.Constants;
using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

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

        public async Task<EcommerceShop.Domain.Entities.Product.Product?> GetById(int id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<(IEnumerable<EcommerceShop.Domain.Entities.Product.Product>, int)> GetAll(string? searchPhrase,
        int pageSize,
        int pageNumber)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                       || r.Description.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();

            var products = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<(IEnumerable<EcommerceShop.Domain.Entities.Product.Product>, int)> GetByCategory(string categoryName, string? searchPhrase, int pageSize, int pageNumber)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Items)
                    .ThenInclude(i => i.Size)
                .Include(p => p.Images)
                .Where(p => p.Category.Name == categoryName)
                .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                       || r.Description.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();

            var products = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }
    }
}
