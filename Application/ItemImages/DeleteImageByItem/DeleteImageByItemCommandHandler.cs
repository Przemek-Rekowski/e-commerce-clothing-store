using Domain.Interfaces.Product;
using MediatR;

namespace Application.ItemImages.DelateImageByItem
{
    public class DeleteImageByItemCommandHandler : IRequestHandler<DelateImageByItemCommand, Unit>
    {
        private readonly IItemImageRepository _repository;
        public DeleteImageByItemCommandHandler(IItemImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DelateImageByItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByItem(request.ItemSku);

            return Unit.Value;
        }
    }
}
