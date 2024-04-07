using Domain.Entities.Image;

namespace Domain.Interfaces.Image
{
    public interface IProductImageRepository
    {
        Task Create(ProductImage productImage);
        Task<ProductImage?> GetById(int id);
        Task<List<ProductImage>> GetAllByProduct(int productId);
        Task Delete(ProductImage image);
        Task DeleteByProduct(int productId);
    }
}
