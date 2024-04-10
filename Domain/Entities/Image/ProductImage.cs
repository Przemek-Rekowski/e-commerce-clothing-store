using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceShop.Domain.Entities.Product;

namespace Domain.Entities.Image
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;

        public virtual Product Product { get; set; } = default!;
    }
}
