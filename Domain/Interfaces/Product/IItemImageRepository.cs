using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceShop.Domain.Entities.Product;

namespace Domain.Interfaces.Product
{
    public interface IItemImageRepository
    {
        Task Create(ItemImage productImage);
        Task<ItemImage> GetById(int id);
        Task<List<ItemImage>> GetAllByItem(string sku);
        Task Delete(ItemImage image);
        Task DeleteByItem(string sku);
    }
}

