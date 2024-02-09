using Domain.Entities.Product;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
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
        _dbContext.Items.Remove(product);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<ProductItem>> GetAll()
        => await _dbContext.Items.ToListAsync();

    public async Task<ProductItem?> GetBySku(string sku)
                => await _dbContext.Items.FirstOrDefaultAsync(i => i.SKU == sku);
}
