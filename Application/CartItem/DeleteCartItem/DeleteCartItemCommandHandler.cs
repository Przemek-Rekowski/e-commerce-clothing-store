using Domain.Interfaces.Cart;
using MediatR;

namespace EcommerceShop.Application.CartItem.DeleteCartItem
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Unit>
    {
        private readonly ICartItemRepository _repository;
        public DeleteCartItemCommandHandler(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetById(request.Id!);

            await _repository.Delete(item);

            return Unit.Value;
        }
    }

}