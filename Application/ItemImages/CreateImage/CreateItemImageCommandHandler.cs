using Application.ItemImages.CreateItemImage;
using AutoMapper;
using Domain.Interfaces.Product;
using EcommerceShop.Domain.Entities.Product;
using MediatR;

namespace Application.ItemImages.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateItemImageCommand, Unit>
    {
        private readonly IItemImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IItemImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateItemImageCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<ItemImage>(request);

            await _imageRepository.Create(image);

            return Unit.Value;
        }
    }
}
