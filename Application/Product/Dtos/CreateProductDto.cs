using Domain.Entities;

namespace Application.Product.Dtos
{
    internal class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Domain.Entities.Inventory> Inventories { get; set; }
    }
}
