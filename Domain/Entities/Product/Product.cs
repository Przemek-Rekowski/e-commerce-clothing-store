namespace Domain.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual List<ProductItem> Items { get; set; } = new();
    }
}
