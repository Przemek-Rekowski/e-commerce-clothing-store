using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product carWorkshop);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Delete(Product product);
        Task Commit();
    }
}
