using Application.Product.Dtos;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Product.Application.Product.GetProductById;

namespace Product.Application.Product.Queries.GetProductByEncodedName
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