namespace Domain.Entities.Product
{
    public class Size
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;
        public List<ProductItem> Items { get; set; } = new();
    }
}
