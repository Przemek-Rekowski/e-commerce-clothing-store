namespace EcommerceShop.Application.CartItem.Dtos
{
    public class CartItemDto
    {
        public string Name { get; set; } = default!;
        public string Size { get; set; } = default!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
