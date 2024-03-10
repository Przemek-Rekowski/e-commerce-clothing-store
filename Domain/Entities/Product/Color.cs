namespace EcommerceShop.Domain.Entities.Product
{
    public class Color
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;
        public virtual List<ProductItem> Items { get; set; } = new();
    }
}
