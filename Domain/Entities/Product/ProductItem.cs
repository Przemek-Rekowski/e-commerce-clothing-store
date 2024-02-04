using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities.Product
{
    public class ProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public string SKU { get; set; } = default!;
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public void GenerateSKU() => SKU = $"{ProductId}-{SizeId}-{ColorId}";
    }
}
