using Domain.Interfaces.Product;
using EcommerceShop.Domain.Entities.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
namespace Infrastructure.Repositories.Product
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public ProductImageRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ProductImage productImage)
        {
            _dbContext.ProductImages.Add(productImage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductImage>> GetAllByProduct(int productId)
            => await _dbContext.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();
        public async Task<ProductImage> GetById(int id)
             => await _dbContext.ProductImages.FirstOrDefaultAsync(pi => pi.Id == id);


        public async Task Delete(ProductImage image)
        {
            _dbContext.ProductImages.Remove(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByProduct(int productId)
        {
            var imagesToDelete = await _dbContext.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();

            _dbContext.ProductImages.RemoveRange(imagesToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
