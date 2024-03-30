using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductImages.Dtos
{
    public class CreateProductImageDto
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;
    }
}
