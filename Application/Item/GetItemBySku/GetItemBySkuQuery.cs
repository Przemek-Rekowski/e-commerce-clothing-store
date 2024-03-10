using EcommerceShop.Application.Item.Dtos;
using MediatR;

namespace EcommerceShop.Application.Item.GetItemBySku
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