using AutoMapper;
using Application.Product.Dtos;
using Application.Item.Dtos;
using Domain.Entities.Product;


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

            CreateMap<CreateProductDto, Domain.Entities.Product.Product>();

            CreateMap<ProductItem, ItemDto>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                        .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Value))
                        .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value));


            CreateMap<CreateItemDto, Domain.Entities.Product.ProductItem>();
        }
    }
}
