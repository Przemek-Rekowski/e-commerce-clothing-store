namespace EcommerceShop.Application.Item.Dtos
{
    public class CreateItemDto
    {
        public string? SKU { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
