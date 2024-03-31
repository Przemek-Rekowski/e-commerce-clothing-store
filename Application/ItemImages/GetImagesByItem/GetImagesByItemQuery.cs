using Application.ItemImages.Dtos;
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
    public class GetImagesByItemQuery : IRequest<IEnumerable<ItemImageDto>>
    {
        public string Sku { get; set; }

        public GetImagesByItemQuery(string sku)
        {
            Sku = sku;
        }
    }
}
