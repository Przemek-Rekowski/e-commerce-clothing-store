using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class InventoryRepository : IInventoryRepository
{
    private readonly EcommerceShopDbContext _dbContext;

    public InventoryRepository(EcommerceShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Inventory inventory)
    {
        _dbContext.Add(inventory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Inventory inventory)
    {
        _dbContext.Inventories.Remove(inventory);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Inventory?> GetByProduct(int productId)
        => await _dbContext.Inventories.FirstOrDefaultAsync(i => i.ProductId == productId);
}
