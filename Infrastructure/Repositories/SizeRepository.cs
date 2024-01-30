using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class SizeRepository : ISizeRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public SizeRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(ProductSize size)
    {
        _dbContext.Add(size);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductSize size)
    {
        _dbContext.Sizes.Remove(size);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<ProductSize?> GetByProduct(int productId)
        => await _dbContext.Sizes.FirstOrDefaultAsync(i => i.ProductId == productId);
}
