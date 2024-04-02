using MediatR;

namespace EcommerceShop.Application.ItemImages.DeleteImage
{
    public class DeleteItemImageCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
        public DeleteItemImageCommand(int id)
        {
            Id = id;
        }
    }
}