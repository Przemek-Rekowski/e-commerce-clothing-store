using Domain.Interfaces.Product;
using MediatR;

namespace EcommerceShop.Application.Product.DeleteProduct
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

            if (product != null)
            {
                await _repository.Delete(product);
            }

            return Unit.Value;
        }

    }

}