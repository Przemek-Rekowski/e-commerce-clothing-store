using EcommerceShop.Domain.Entities.Product;

namespace Domain.Interfaces.Product
{
    public interface ICategoryRepository
    {
        Task Create(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetByName(string name);
        Task<Category?> GetById(int id);
        Task Delete(Category category);
        Task Commit();
    }
}
