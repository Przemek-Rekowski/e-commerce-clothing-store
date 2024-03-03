namespace EcommerceShop.Domain.Entities.Cart
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<CartItem> Items { get; set; } = [];
        public virtual User.User Owner { get; set; } = default!;
    }
}
