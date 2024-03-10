using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Product;
internal class CategoryRepository : ICategoryRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public CategoryRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
     => _dbContext.SaveChangesAsync();

    public async Task Create(EcommerceShop.Domain.Entities.Product.Category category)
    {
        _dbContext.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(EcommerceShop.Domain.Entities.Product.Category category)
    {
        _dbContext.Categories.Remove(category);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Category>> GetAll()
        => await _dbContext.Categories.ToListAsync();

    public async Task<EcommerceShop.Domain.Entities.Product.Category?> GetById(int id)
                => await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<EcommerceShop.Domain.Entities.Product.Category?> GetByName(string name)
        => await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
}
