namespace Application.Item.Dtos
{
    public class ItemDto
    {
        public string SKU { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Size { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
