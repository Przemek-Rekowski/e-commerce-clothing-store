using Domain.Entities.Image;
using Domain.Interfaces.Image;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.Image
{
    public class ItemImageRepository : IItemImageRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public ItemImageRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ItemImage itemImage)
        {
            _dbContext.ItemImages.Add(itemImage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ItemImage>> GetAllByItem(string itemSku)
            => await _dbContext.ItemImages
                .Where(pi => pi.ItemSku == itemSku)
                .ToListAsync();
        public async Task<ItemImage?> GetById(int id)
             => await _dbContext.ItemImages.FirstOrDefaultAsync(pi => pi.Id == id);

        public async Task Delete(ItemImage image)
        {
            _dbContext.ItemImages.Remove(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByItem(string itemSku)
        {
            var imagesToDelete = await _dbContext.ItemImages
                .Where(pi => pi.ItemSku == itemSku)
                .ToListAsync();

            _dbContext.ItemImages.RemoveRange(imagesToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
