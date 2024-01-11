using MediatR;

namespace EcommerceShop.Application.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}