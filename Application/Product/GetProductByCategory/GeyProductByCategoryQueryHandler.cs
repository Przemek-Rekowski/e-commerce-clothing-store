using AutoMapper;
using Domain.Interfaces;
using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByCategory(request.CategoryId);

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}