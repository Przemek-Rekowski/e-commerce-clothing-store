namespace EcommerceShop.Domain.Entities.Product
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public virtual Category Parent { get; set;}
        public virtual List<Product> Products { get; set;}
    }
}
