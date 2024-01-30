using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISizeRepository
    {
        Task Create(ProductSize size);
        Task<ProductSize?> GetByProduct(int productId);
        Task Delete(ProductSize size);
    }
}
