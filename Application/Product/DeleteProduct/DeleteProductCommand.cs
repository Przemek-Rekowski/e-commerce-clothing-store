using MediatR;

namespace EcommerceShop.Application.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
    }
}