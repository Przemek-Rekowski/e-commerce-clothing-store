using Application.ProductImages.Dtos;
using AutoMapper;
using Domain.Interfaces.Product;
using EcommerceShop.Domain.Entities.Product;
using MediatR;

namespace Application.ProductImages.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IProductImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<ProductImage>(request);

            await _imageRepository.Create(image);

            return Unit.Value;
        }
    }
}
