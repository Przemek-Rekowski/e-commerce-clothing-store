using Application.Inventory.Dtos;
using Application.Product.Dtos;
using AutoMapper;


namespace Application.Mappings
{
    public class EcommerceShopMappingProfile : Profile
    {
        public EcommerceShopMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<ProductDto, Domain.Entities.Product>();

            CreateMap<Domain.Entities.Inventory, InventoryDto>();
            CreateMap<InventoryDto, Domain.Entities.Inventory>();
        }
    }
}
