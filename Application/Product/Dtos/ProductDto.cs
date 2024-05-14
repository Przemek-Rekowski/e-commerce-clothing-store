using Application.ProductImages.Dtos;

namespace EcommerceShop.Application.Product.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public bool IsAvalible { get; set; }
        public string Category { get; set; } = default!;

        public List<SizeDto> SizeDtos { get; set; } = new();
        public List<ProductImageDto> Images { get; set; } = new();
    }
}
