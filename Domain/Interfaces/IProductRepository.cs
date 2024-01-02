using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product carWorkshop);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Delete(int id);
        Task Commit();
    }
}
