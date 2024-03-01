using AutoMapper;
using Domain.Interfaces;
using EcommerceShop.Application.Category.Dtos;
using MediatR;

namespace EcommerceShop.Application.Category.GetAllCategories
{
    public class GetAllCategorysQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategorysQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);


            return dtos;
        }
    }
}