using Application.Product;
using AutoMapper;


namespace Application.Mappings
{
    public class EcommerceShopMappingProfile : Profile
    {
        public EcommerceShopMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<ProductDto, Domain.Entities.Product>();
        }
    }
}
