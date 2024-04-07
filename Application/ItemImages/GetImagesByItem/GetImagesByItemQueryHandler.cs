using Application.ItemImages.Dtos;
using Application.ProductImages.Dtos;
using AutoMapper;
using Domain.Interfaces.Image;
using MediatR;

namespace Application.ProductImages.GetImageByProduct
{
    public class GetImagesByItemQueryHandler : IRequestHandler<GetImagesByItemQuery, IEnumerable<ItemImageDto>>
    {
        private readonly IItemImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImagesByItemQueryHandler(IItemImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemImageDto>> Handle(GetImagesByItemQuery request, CancellationToken cancellationToken)
        {
            var images = await _imageRepository.GetAllByItem(request.Sku);
            var dtos = _mapper.Map<IEnumerable<ItemImageDto>>(images);

            return dtos;
        }
    }
}
