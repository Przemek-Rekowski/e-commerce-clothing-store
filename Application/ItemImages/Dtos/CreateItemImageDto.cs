namespace Application.ItemImages.Dtos
{
    public class CreateItemImageDto
    {
        public string ItemSku { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
