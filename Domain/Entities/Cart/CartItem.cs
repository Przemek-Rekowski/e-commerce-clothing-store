namespace EcommerceShop.Domain.Entities.Cart
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
