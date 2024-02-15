namespace Domain.Entities.Product
{
    public class ProductItem
    {
        public string SKU { get; set; } = default!;
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product Product { get; set; } = default!;
        public Size Size { get; set; } = default!;
        public Color Color { get; set; } = default!;

        public void GenerateSKU() => SKU = $"{ProductId}-{SizeId}-{ColorId}";
    }
}
