using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public string Quantity { get; set; }
    }
}
