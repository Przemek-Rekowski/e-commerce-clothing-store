using Domain.Interfaces;
using MediatR;

namespace EcommerceShop.Application.Item.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IProductItemRepository _repository;
        public DeleteItemCommandHandler(IProductItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetBySku(request.SKU!);

            await _repository.Delete(item);

            return Unit.Value;
        }
    }

}