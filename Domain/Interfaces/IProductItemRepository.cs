using Domain.Entities.Product;

namespace Domain.Interfaces
{
    public interface IProductItemRepository
    {
        Task Create(ProductItem item);
        Task<IEnumerable<ProductItem>> GetAll();
        Task<ProductItem?> GetBySku(string sku);
        Task Delete(ProductItem item);
        Task Commit();
    }
}
