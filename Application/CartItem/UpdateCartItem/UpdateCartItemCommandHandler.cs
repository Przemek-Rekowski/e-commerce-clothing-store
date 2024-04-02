using Domain.Interfaces.Cart;
using MediatR;

namespace EcommerceShop.Application.CartItem.UpdateCartItem
{
    internal class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, Unit>
    {
        private readonly ICartItemRepository _repository;

        public UpdateCartItemCommandHandler(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetById(request.Id);

            if (item != null)
            {
                item.Quantity = request.Quantity;
                await _repository.Commit();
            }

            return Unit.Value;
        }
    }
}
