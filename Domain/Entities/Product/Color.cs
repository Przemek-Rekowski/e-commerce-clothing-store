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
        public string Value { get; set; }
        public List<ProductItem> Items { get; set; }
    }
}
