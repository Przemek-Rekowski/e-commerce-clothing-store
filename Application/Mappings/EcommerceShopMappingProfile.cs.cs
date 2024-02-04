using AutoMapper;
using Application.Product.Dtos;


namespace Application.Mappings
{
    public class EcommerceShopMappingProfile : Profile
    {
        public EcommerceShopMappingProfile()
        {
            CreateMap<Domain.Entities.Product.Product, ProductDto>()
                           .ForMember(dest => dest.SizeDtos, opt => opt.MapFrom(src => src.Items.Select(item => new SizeDto
                           {
                               Value = item.Size.Value,
                               IsAvalible = item.Quantity > 0
                           })))
                           .ForMember(dest => dest.IsAvalible, opt => opt.MapFrom(src => src.Items.Any(item => item.Quantity > 0)));
        }
    }
}
