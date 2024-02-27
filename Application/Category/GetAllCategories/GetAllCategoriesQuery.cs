using EcommerceShop.Application.Category.Dtos;
using MediatR;

namespace EcommerceShop.Application.Category.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}