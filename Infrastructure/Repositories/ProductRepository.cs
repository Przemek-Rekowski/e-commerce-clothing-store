using Domain.Entities;
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

    public async Task Create(Product carWorkshop)
    {
        _dbContext.Add(carWorkshop);
        await _dbContext.SaveChangesAsync();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAll()
        => await _dbContext.Products.ToListAsync();

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByName(string name)
     => _dbContext.Products.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
}
