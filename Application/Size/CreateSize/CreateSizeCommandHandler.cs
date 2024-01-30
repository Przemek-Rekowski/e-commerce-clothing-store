using Application.Size.CreateSize;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace EcommerceShop.Application.Size.CreateSize
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, Unit>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public CreateSizeCommandHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            var size = _mapper.Map<Domain.Entities.ProductSize>(request);

            await _sizeRepository.Create(size);

            return Unit.Value;
        }
    }
}
