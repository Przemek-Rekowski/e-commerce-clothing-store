using Application.Product.Dtos;
using AutoMapper;
using Xunit;
using Domain.Entities.Product;
using Application.Item.Dtos;

namespace Application.Mappings.Tests
{
    public class EcommerceShopMappingProfileTests
    {
        [Fact]
        public void MappingProfile_ShouldMapProductDtoToProductDto()
        {
            //arrange
            var configuration = new MapperConfiguration(cfg =>
                 cfg.AddProfile(new EcommerceShopMappingProfile()));

            var mapper = configuration.CreateMapper();

            var product = new Domain.Entities.Product.Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Items = new List<ProductItem>
                {
                    new ProductItem { Size = new Size { Value = "S" }, Quantity = 5 },
                    new ProductItem { Size = new Size { Value = "M" }, Quantity = 0 }
                }
            };

            //act
            var productDto = mapper.Map<ProductDto>(product);

            //assert
            Assert.NotNull(productDto);
            Assert.Equal(product.Name, productDto.Name);
            Assert.Equal(product.Description, productDto.Description);

            Assert.NotNull(productDto.SizeDtos);
            Assert.Equal(2, productDto.SizeDtos.Count);

            Assert.True(productDto.IsAvalible);
        }

        [Fact]
        public void MappingProfile_ShouldMapCreateProductDtoToProduct()
        {
            //arrange
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new EcommerceShopMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new CreateProductDto
            {
                Name = "name",
                Description = "description",
            };

            //act
            var result = mapper.Map<Domain.Entities.Product.Product>(dto);

            //assert
            Assert.NotNull(result);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Description, result.Description);
        }

        [Fact]
        public void MappingProfile_ShouldMapProductItemToItemDto()
        {
            //arrange
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductItem, ItemDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Value))
                    .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value));
            });

            var mapper = configuration.CreateMapper();

            //act
            var item = new ProductItem
            {
                SKU = "1-1-1",
                Quantity = 1,
                Price = 100,
                Product = new Domain.Entities.Product.Product
                {
                    Name = "name",
                    Description = "description",

                },
                Size = new Size { Value = "L" },
                Color = new Color { Value = "red" }
            };

            var destination = mapper.Map<ItemDto>(item);

            //assert
            Assert.Equal("1-1-1", destination.SKU);
            Assert.Equal(1, destination.Quantity);
            Assert.Equal(100, destination.Price);
            Assert.Equal("name", destination.Name);
            Assert.Equal("L", destination.Size);
            Assert.Equal("red", destination.Color);
        }

        [Fact]
        public void MappingProfile_ShouldMapCreateItemDtoToItem()
        {
            //arrange
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new EcommerceShopMappingProfile()));

            var mapper = configuration.CreateMapper();

            var dto = new CreateItemDto
            {
                SKU = "1-1-1",
                ProductId = 1,
                SizeId = 1,
                ColorId = 1,
                Quantity = 1,
                Price = 100,
            };

            //act
            var result = mapper.Map<Domain.Entities.Product.ProductItem>(dto);

            //assert
            Assert.NotNull(result);
            Assert.Equal(dto.SKU, result.SKU);
            Assert.Equal(dto.ProductId, result.ProductId);
            Assert.Equal(dto.SizeId, result.SizeId);
            Assert.Equal(dto.ColorId, result.ColorId);
            Assert.Equal(dto.Quantity, result.Quantity);
            Assert.Equal(dto.Price, result.Price);
        }
    }
}
