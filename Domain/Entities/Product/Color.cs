using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Color
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;
        public List<ProductItem> Items { get; set; } = new();
    }
}
