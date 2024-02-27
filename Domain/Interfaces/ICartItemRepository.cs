using Domain.Entities.Cart;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartItemRepository
    {
        Task Create(CartItem item);
        Task<CartItem?> GetById(int id);
        Task Delete(CartItem item);
        Task Commit();
    }
}
