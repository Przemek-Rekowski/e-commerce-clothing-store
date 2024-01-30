namespace Domain.Entities
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public string Quantity { get; set; }

        public Product Product { get; set; }
    }
}
