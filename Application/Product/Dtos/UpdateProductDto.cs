namespace EcommerceShop.Application.Product.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
