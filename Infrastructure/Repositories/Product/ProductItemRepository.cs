using Domain.Interfaces.Product;
using EcommerceShop.Domain.Entities.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Product;
internal class ProductItemRepository : IProductItemRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public ProductItemRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
     => _dbContext.SaveChangesAsync();

    public async Task Create(ProductItem product)
    {
        _dbContext.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductItem product)
    {
        _dbContext.ProductItems.Remove(product);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<ProductItem>> GetAll()
        => await _dbContext.ProductItems.ToListAsync();

    public async Task<ProductItem?> GetBySku(string sku)
                => await _dbContext.ProductItems.FirstOrDefaultAsync(pi => pi.SKU == sku);
}
