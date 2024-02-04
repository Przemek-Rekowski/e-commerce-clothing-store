using Application.Product.Dtos;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Product.Application.Product.GetProductById;

namespace Product.Application.Product.Queries.GetProductByEncodedName
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