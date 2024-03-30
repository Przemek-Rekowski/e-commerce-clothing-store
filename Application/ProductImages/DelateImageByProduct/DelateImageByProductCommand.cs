using MediatR;

namespace Application.ProductImages.DelateImageByProduct
{
    public class DelateImageByProductCommand : IRequest<Unit>
    {
        public int ProductId { get; set; } = default!;
        public DelateImageByProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
