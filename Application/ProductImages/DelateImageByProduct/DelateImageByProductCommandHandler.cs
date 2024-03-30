using Domain.Interfaces.Product;
using MediatR;

namespace Application.ProductImages.DelateImageByProduct
{
    public class DeleteImageByProductCommandHandler : IRequestHandler<DelateImageByProductCommand, Unit>
    {
        private readonly IProductImageRepository _repository;
        public DeleteImageByProductCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DelateImageByProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByProduct(request.ProductId);

            return Unit.Value;
        }
    }
}
