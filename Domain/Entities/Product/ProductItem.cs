namespace EcommerceShop.Domain.Entities.Product
{
    public class ProductItem
    {
        public string SKU { get; set; } = default!;
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Product Product { get; set; } = default!;
        public virtual Size Size { get; set; } = default!;
        public virtual Color Color { get; set; } = default!;

        public void GenerateSKU() => SKU = $"{ProductId}-{SizeId}-{ColorId}";
    }
}
