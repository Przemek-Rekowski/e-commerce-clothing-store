using Domain.Entities.Product;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class ProductRepository : IProductRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public ProductRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
     => _dbContext.SaveChangesAsync();

    public async Task Create(Product product)
    {
        _dbContext.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        var itemsToRemove = _dbContext.Items.Where(i => i.ProductId == product.Id).ToList();

        _dbContext.Items.RemoveRange(itemsToRemove);
        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<Product>> GetAll()
        => await _dbContext.Products.ToListAsync();

    public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        => await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();


    public async Task<Product?> GetById(int id)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
}
