using MediatR;

namespace EcommerceShop.Application.Item.DeleteItem
{
    public class DeleteItemCommand : IRequest<Unit>
    {
        public string SKU { get; set; } = default!;
        public DeleteItemCommand(string sku)
        {
            SKU = sku;
        }
    }
}