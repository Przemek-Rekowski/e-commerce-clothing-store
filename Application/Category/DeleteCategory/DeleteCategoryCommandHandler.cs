using Domain.Interfaces;
using EcommerceShop.Application.Category.DeleteCategory;
using MediatR;

namespace TaskManager.Application.Category.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetById(request.Id!);

            await _repository.Delete(category);

            return Unit.Value;
        }
    }

}