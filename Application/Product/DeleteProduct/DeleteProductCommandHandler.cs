using Domain.Interfaces;
using EcommerceShop.Application.Product.DeleteProduct;
using MediatR;

namespace TaskManager.Application.Product.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id!);

            await _repository.Delete(product);

            return Unit.Value;
        }
    }

}