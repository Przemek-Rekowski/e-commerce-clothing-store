using Domain.Interfaces.Product;
using EcommerceShop.Application.Category.UpdateCategory;
using MediatR;

namespace Category.Application.Category.Commands.UpdateCategory
{
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetById(request.Id);

            category.Name = request.Name;
            category.ParentId = request.ParentId;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
