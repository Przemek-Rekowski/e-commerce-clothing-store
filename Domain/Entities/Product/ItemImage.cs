namespace EcommerceShop.Domain.Entities.Product
{
    public class ItemImage
    {
        public int Id { get; set; }
        public string ItemSku { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;

        public virtual ProductItem Item { get; set; } = default!;
    }
}
