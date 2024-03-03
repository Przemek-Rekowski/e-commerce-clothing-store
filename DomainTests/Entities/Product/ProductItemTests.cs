using EcommerceShop.Domain.Entities.Product;
using Xunit;

namespace Domain.Entities.Product.Tests
{
    public class ProductItemTests
    {
        [Fact]
        public void GenerateSKU_ShouldGenerateCorrectSKU()
        {
            //arrange
            var productItem = new ProductItem
            {
                ProductId = 1,
                SizeId = 2,
                ColorId = 3
            };

            //act
            productItem.GenerateSKU();

            //assert
            Assert.Equal("1-2-3", productItem.SKU);
        }
    }
}