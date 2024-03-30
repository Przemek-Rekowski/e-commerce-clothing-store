using Application.ProductImages.Dtos;
using EcommerceShop.Application.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductImages.GetImageByProduct
{
    public class GetImagesByProductQuery: IRequest<IEnumerable<ProductImageDto>>
    {
        public int Id { get; set; }

        public GetImagesByProductQuery(int id)
        {
            Id = id;
        }
    }
}
