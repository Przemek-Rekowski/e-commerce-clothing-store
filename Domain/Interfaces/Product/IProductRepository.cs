using Domain.Constants;

namespace Domain.Interfaces.Product
{
    public interface IProductRepository
    {
        Task Create(EcommerceShop.Domain.Entities.Product.Product product);
        Task<(IEnumerable<EcommerceShop.Domain.Entities.Product.Product>, int)> GetAll(string? searchPhrase,
        int pageSize,
        int pageNumber);
        Task<EcommerceShop.Domain.Entities.Product.Product?> GetById(int id);
        Task<PagedResult<EcommerceShop.Domain.Entities.Product.Product>> GetByCategory(string category, DatabaseQuery query);
        Task Delete(EcommerceShop.Domain.Entities.Product.Product product);
        Task Commit();
    }
}
