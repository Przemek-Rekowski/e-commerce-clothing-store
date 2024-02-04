using Domain.Entities.Product;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Delete(Product product);
        Task Commit();
    }
}
