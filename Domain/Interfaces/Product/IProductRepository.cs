using EcommerceShop.Domain.Entities.Product;

namespace Domain.Interfaces.Product
{
    public interface IProductRepository
    {
        Task Create(EcommerceShop.Domain.Entities.Product.Product product);
        Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetAll();
        Task<EcommerceShop.Domain.Entities.Product.Product?> GetById(int id);
        Task<IEnumerable<EcommerceShop.Domain.Entities.Product.Product>> GetByCategory(int categoryId);
        Task Delete(EcommerceShop.Domain.Entities.Product.Product product);
        Task Commit();
    }
}
