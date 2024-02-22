using Application.Category.Dtos;
using MediatR;

namespace Application.Category.CreateCategory
{
    public class CreateCategoryCommand : CategoryUtilityDto, IRequest<Unit>
    {
    }
}