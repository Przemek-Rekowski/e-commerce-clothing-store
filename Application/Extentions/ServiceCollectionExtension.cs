using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Application.Mappings;

namespace EcommerceShop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            // Register MediatR and other services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // Register AutoMapper
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                cfg.AddProfile(new EcommerceShopMappingProfile());
            }).CreateMapper());
        }
    }
}
