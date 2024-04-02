using Application.ItemImages.Dtos;
using MediatR;

namespace Application.ItemImages.CreateItemImage
{
    public class CreateItemImageCommand : CreateItemImageDto, IRequest<Unit>
    {
    }
}
