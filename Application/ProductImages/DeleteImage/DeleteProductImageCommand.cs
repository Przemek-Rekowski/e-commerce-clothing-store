using MediatR;

namespace EcommerceShop.Application.Image.DeleteImage
{
    public class DeleteProductImageCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
        public DeleteProductImageCommand(int id)
        {
            Id = id;
        }
    }
}