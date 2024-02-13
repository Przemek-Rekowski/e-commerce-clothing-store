using Application.Item.Dtos;
using MediatR;

namespace Product.Application.Product.GetProductById
{
    public class GetItemBySkuQuery : IRequest<ItemDto>
    {
        public string SKU { get; set; }

        public GetItemBySkuQuery(string sku)
        {
            SKU = sku;
        }
    }
}