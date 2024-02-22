namespace Application.Category.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; } = default!;
        public CategoryDto? Parent { get; set; } = default!;
    }
}
