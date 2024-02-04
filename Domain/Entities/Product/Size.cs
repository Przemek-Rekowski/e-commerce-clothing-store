namespace Domain.Entities.Product
{
    public class Size
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<ProductItem> Items { get; set; }
    }
}
