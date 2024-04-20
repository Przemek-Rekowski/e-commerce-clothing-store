namespace EcommerceShop.Domain.Entities.Product
{
    public class Category
    {
        public string Name { get; set; } = default!;

        public  List<Product> Products { get; set;} = new();
    }
}
