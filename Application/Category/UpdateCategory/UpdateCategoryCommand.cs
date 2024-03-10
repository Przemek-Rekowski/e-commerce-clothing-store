using EcommerceShop.Application.Category.Dtos;
using MediatR;

namespace EcommerceShop.Application.Category.UpdateCategory
{
    public class UpdateCategoryCommand : CategoryUtilityDto, IRequest<Unit>
    {
        public int Id;

        public UpdateCategoryCommand(int id)
        {
            Id = id;
        }
    }
}