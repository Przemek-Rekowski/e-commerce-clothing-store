using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace EcommerceShop.Application.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product.Product>(request);

            await _productRepository.Create(product);

            return Unit.Value;
        }
    }
}
