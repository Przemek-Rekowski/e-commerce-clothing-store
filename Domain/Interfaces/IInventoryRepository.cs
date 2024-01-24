using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task Create(Inventory inventory);
        Task<Inventory?> GetByProduct(int productId);
        Task Delete(Inventory inventory);
    }
}
