using EcommerceShop.Domain.Entities.Product;

namespace Domain.Interfaces.Product
{
    public interface IProductItemRepository
    {
        Task Create(ProductItem item);
        Task<(IEnumerable<ProductItem>, int)> GetAll(string? searchPhrase, 
            int pageSize,
            int pageNumber);
        Task<ProductItem?> GetBySku(string sku);
        Task Delete(ProductItem item);
        Task Commit();
    }
}
