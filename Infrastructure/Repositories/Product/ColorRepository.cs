using Domain.Interfaces.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Product
{
    internal class ColorRepository : IColorRepository
    {
        private readonly EcommerceShopDbContext _dbContext;

        public ColorRepository(EcommerceShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task GetById(int id)
            => await _dbContext.Colors.FirstOrDefaultAsync(c => c.Id == id);
    }
}
