using Application.Category.CreateCategory;
using AutoMapper;
using Domain.Interfaces.Product;
using MediatR;

namespace EcommerceShop.Application.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Product.Category>(request);
            category.Name.ToLower();

            await _categoryRepository.Create(category);

            return Unit.Value;
        }
    }
}
