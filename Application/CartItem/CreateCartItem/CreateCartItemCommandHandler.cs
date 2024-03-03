using AutoMapper;
using Domain.Interfaces.Cart;
using MediatR;

namespace EcommerceShop.Application.CartItem.CreateCartItem
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, Unit>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemtemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemtemRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Domain.Entities.Cart.CartItem>(request);

            await _cartItemRepository.Create(item);

            return Unit.Value;
        }
    }
}
