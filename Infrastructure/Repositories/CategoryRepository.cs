using Domain.Entities.Product;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class CategoryRepository : ICategoryRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public CategoryRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit()
     => _dbContext.SaveChangesAsync();

    public async Task Create(Category category)
    {
        _dbContext.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _dbContext.Categories.Remove(category);

        await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<Category>> GetAll()
        => await _dbContext.Categories.ToListAsync();

    public async Task<Category?> GetById(int id)
                => await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Category?> GetByName(string name)
        => await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
}
