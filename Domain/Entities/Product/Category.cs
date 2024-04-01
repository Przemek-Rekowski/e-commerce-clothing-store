namespace EcommerceShop.Domain.Entities.Product
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = default!;

        public virtual Category Parent { get; set; } = new();
        public virtual List<Product> Products { get; set;} = new();
    }
}
