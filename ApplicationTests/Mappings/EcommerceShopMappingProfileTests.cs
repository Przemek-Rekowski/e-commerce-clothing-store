using AutoMapper;
using EcommerceShop.Domain.Entities.Product;
using EcommerceShop.Application.Category.Dtos;
using EcommerceShop.Application.Item.Dtos;
using EcommerceShop.Application.Mappings;
using EcommerceShop.Application.Product.Dtos;
using Xunit;

namespace Application.Mappings.Tests
{
    public class EcommerceShopMappingProfileTests
    {
        private IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new EcommerceShopMappingProfile()));
            return configuration.CreateMapper();
        }

        [Fact]
        public void MappingProfile_ShouldMapProductDtoToProductDto()
        {
            //arrange
            var mapper = GetMapper();
            var product = new EcommerceShop.Domain.Entities.Product.Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Category = new EcommerceShop.Domain.Entities.Product.Category
                {
                    Id = 1,
                    //ParentId = 2,
                    Name = "test name",
                },
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
            Assert.Equal($"{product.Name} {product.Category.Name}", productDto.Name);
            Assert.Equal(product.Description, productDto.Description);
            Assert.Equal(product.Category.Name, productDto.Category);

            Assert.NotNull(productDto.SizeDtos);
            Assert.Equal(product.Items.Count, productDto.SizeDtos.Count);

            Assert.True(productDto.IsAvalible);
        }

        [Fact]
        public void MappingProfile_ShouldMapCreateProductDtoToProduct()
        {
            //arrange
            var mapper = GetMapper();
            var dto = new CreateProductDto
            {
                Name = "name",
                Description = "description",
            };

            //act
            var result = mapper.Map<EcommerceShop.Domain.Entities.Product.Product>(dto);

            //assert
            Assert.NotNull(result);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Description, result.Description);
        }

        [Theory]
        [InlineData("1-1-1", 1, 100, "name", "L", "red")]
        [InlineData("2-2-2", 2, 150, "other", "M", "blue")]
        public void MappingProfile_ShouldMapProductItemToItemDto(string sku, int quantity, int price, string productName, string size, string color)
        {
            //arrange
            var mapper = GetMapper();
            var item = new ProductItem
            {
                SKU = sku,
                Quantity = quantity,
                Price = price,
                Product = new EcommerceShop.Domain.Entities.Product.Product
                {
                    Name = productName,
                },
                Size = new Size { Value = size },
                Color = new Color { Value = color }
            };

            //act
            var destination = mapper.Map<ItemDto>(item);

            //assert
            Assert.Equal(sku, destination.SKU);
            Assert.Equal(quantity, destination.Quantity);
            Assert.Equal(price, destination.Price);
            Assert.Equal(productName, destination.Name);
            Assert.Equal(size, destination.Size);
            Assert.Equal(color, destination.Color);
        }

        [Fact]
        public void MappingProfile_ShouldMapCreateItemDtoToItem()
        {
            //arrange
            var mapper = GetMapper();
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
            var result = mapper.Map<ProductItem>(dto);

            //assert
            Assert.NotNull(result);
            Assert.Equal(dto.SKU, result.SKU);
            Assert.Equal(dto.ProductId, result.ProductId);
            Assert.Equal(dto.SizeId, result.SizeId);
            Assert.Equal(dto.ColorId, result.ColorId);
            Assert.Equal(dto.Quantity, result.Quantity);
            Assert.Equal(dto.Price, result.Price);
        }

        [Fact]
        public void MappingProfile_ShouldMapCategoryToCategoryDto()
        {
            //arrange
            var mapper = GetMapper();
            var category = new EcommerceShop.Domain.Entities.Product.Category
            {
                Id = 1,
                //ParentId = 2,
                Name = "test name",
                //Parent = new EcommerceShop.Domain.Entities.Product.Category { Id = 2, Name = "parent name" }
            };

            //act
            var categoryDto = mapper.Map<CategoryDto>(category);

            //assert
            Assert.NotNull(categoryDto);
            Assert.Equal(category.Name, categoryDto.Name);
            //Assert.NotNull(categoryDto.Parent);
           // Assert.Equal(category.Parent.Name, categoryDto.Parent.Name);
        }
    }
}
