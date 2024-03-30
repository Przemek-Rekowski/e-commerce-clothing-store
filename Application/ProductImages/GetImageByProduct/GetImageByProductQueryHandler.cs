using Application.ProductImages.Dtos;
using AutoMapper;
using Domain.Interfaces.Product;
using MediatR;

namespace Application.ProductImages.GetImageByProduct
{
    public class GetImagesByProductQueryHandler : IRequestHandler<GetImagesByProductQuery, IEnumerable<ProductImageDto>>
    {
        private readonly IProductImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImagesByProductQueryHandler(IProductImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductImageDto>> Handle(GetImagesByProductQuery request, CancellationToken cancellationToken)
        {
            var images = await _imageRepository.GetAllByProduct(request.Id);
            var dtos = _mapper.Map<IEnumerable<ProductImageDto>>(images);

            return dtos;
        }
    }
}
