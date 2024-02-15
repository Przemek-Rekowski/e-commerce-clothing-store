using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace EcommerceShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceShopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("EcommerceShop")));

            var cn = configuration.GetConnectionString("EcommerceShop");

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
        }
    }
}
