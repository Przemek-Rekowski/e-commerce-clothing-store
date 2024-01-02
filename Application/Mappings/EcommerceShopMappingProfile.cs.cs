using Application.Product;
using Domain.Entities;
using AutoMapper;


namespace Application.Mappings
{
    public class EcommerceShopMappingProfile : Profile
    {
        public EcommerceShopMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>()
                .ForMember(dto => dto.IsAvaliable, opt => opt.MapFrom(src => true));
        }
    }
}
