using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cart
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
    }
}
