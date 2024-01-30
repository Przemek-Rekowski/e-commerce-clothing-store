using Domain.Entities;

namespace Application.Product
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsAvalible { get; set; }

        public List<ProductSize> Size { get; set; }
    }
}
