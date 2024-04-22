using AutoMapper;
using EcommerceShop.Application.Item.Dtos;
using EcommerceShop.Application.Category.Dtos;
using EcommerceShop.Application.CartItem.Dtos;
using EcommerceShop.Application.Product.Dtos;
using EcommerceShop.Domain.Entities.Product;
using Application.ProductImages.Dtos;
using Application.ItemImages.Dtos;
using Domain.Entities.Image;

namespace EcommerceShop.Application.Mappings
{
    public class EcommerceShopMappingProfile : Profile
    {
        public EcommerceShopMappingProfile()
        {
            CreateMap<Domain.Entities.Product.Product, ProductDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.FirstOrDefault()))
                .ForMember(dest => dest.SizeDtos, opt => opt.MapFrom(src => src.Items
                    .GroupBy(item => item.Size.Value)
                    .Select(group => new SizeDto
                    {
                        Value = group.Key,
                        IsAvalible = group.Any(item => item.Quantity > 0)
                    }).ToList()
                ))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.IsAvalible, opt => opt.MapFrom(src => src.Items.Any(item => item.Quantity > 0)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {(src.Category.Name.ToLower())}"));



            CreateMap<CreateProductDto, Domain.Entities.Product.Product>();

            CreateMap<CreateProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<CreateItemImageDto, ItemImage>();
            CreateMap<ItemImage, ItemImageDto>();

            CreateMap<ProductItem, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Value))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => $"{src.Product.Category.Name.ToLower()}"));

            CreateMap<CreateItemDto, ProductItem>();

            CreateMap<Domain.Entities.Product.Category, CategoryDto>();
                //.ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent));

            CreateMap<CategoryUtilityDto, Domain.Entities.Product.Category>();

            CreateMap<Domain.Entities.Cart.CartItem, CartItemDto>();
            CreateMap<CreateCartItemDto, Domain.Entities.Cart.CartItem>();
        }
    }
}