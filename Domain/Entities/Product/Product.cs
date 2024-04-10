using Domain.Entities.Image;

namespace EcommerceShop.Domain.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int CategoryId { get; set; }

        public  Category Category { get; set; } = default!;
        public  List<ProductItem> Items { get; set; } = new();
        public  List<ProductImage> Images { get; set; } = new();
    }
}