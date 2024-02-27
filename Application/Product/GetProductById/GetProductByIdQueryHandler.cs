using AutoMapper;
using Domain.Interfaces;
using EcommerceShop.Application.Product.Dtos;
using MediatR;


namespace EcommerceShop.Application.Product.GetProductsById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}