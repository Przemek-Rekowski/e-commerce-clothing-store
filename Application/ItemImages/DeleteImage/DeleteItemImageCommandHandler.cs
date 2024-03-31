using Domain.Interfaces.Product;
using EcommerceShop.Application.ItemImages.DeleteImage;
using MediatR;

namespace Application.ItemImages.DeleteImage
{
    public class DeleteItemImageCommandHandler : IRequestHandler<DeleteItemImageCommand, Unit>
    {
        private readonly IItemImageRepository _repository;
        public DeleteItemImageCommandHandler(IItemImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteItemImageCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetById(request.Id!);

            await _repository.Delete(item);

            return Unit.Value;
        }
    }
}
