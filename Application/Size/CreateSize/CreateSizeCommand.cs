using Application.Size.Dtos;
using MediatR;

namespace Application.Size.CreateSize
{
    public class CreateSizeCommand : SizeDto, IRequest<Unit>
    {
    }
}