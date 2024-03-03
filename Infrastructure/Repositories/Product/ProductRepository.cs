using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Product;
internal class ProductRepository : IProductRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public ProductRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
     => _dbContext.SaveChangesAsync();

    public async Task Create(EcommerceShop.Domain.Entities.Product.Product product)
    {
        _dbContext.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(EcommerceShop.Domain.Entities.Product.Product product)
    {
        var itemsToRemove = _dbContext.ProductItems.Where(i => i.ProductId == product.Id).ToList();

        _dbContext.ProductItems.RemoveRange(itemsToRemove);
        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetAll()
        => await _dbContext.Products.ToListAsync();

    public async Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetByCategory(int categoryId)
        => await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();


    public async Task<EcommerceShop.Domain.Entities.Product.Product?> GetById(int id)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
}
