using AutoMapper;
using EcommerceShop.Application.Item.Dtos;
using EcommerceShop.Application.Category.Dtos;
using EcommerceShop.Application.CartItem.Dtos;
using EcommerceShop.Application.Product.Dtos;
using EcommerceShop.Domain.Entities.Product;

namespace EcommerceShop.Application.Mappings
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
                .ForMember(dest => dest.IsAvalible, opt => opt.MapFrom(src => src.Items.Any(item => item.Quantity > 0)))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {src.Category.Name.ToLower()}"));

            CreateMap<CreateProductDto, Domain.Entities.Product.Product>();

            CreateMap<ProductItem, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Value))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value));

            CreateMap<CreateItemDto, ProductItem>();

            CreateMap<Domain.Entities.Product.Category, CategoryDto>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent));

            CreateMap<CategoryUtilityDto, Domain.Entities.Product.Category>();

            CreateMap<Domain.Entities.Cart.CartItem, CartItemDto>();
            CreateMap<CreateCartItemDto, Domain.Entities.Cart.CartItem>();
        }
    }
}
