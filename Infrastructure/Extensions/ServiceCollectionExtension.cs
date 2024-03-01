using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Domain.Entities.User;


namespace EcommerceShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("EcommerceShop");
            services.AddDbContext<EcommerceShopDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .UseLazyLoadingProxies());

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<EcommerceShopDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
