namespace Domain.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductItem> Items { get; set; }
    }
}
