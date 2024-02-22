using MediatR;

namespace EcommerceShop.Application.Category.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; } = default!;
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}