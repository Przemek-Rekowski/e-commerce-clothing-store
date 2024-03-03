using Domain.Interfaces.Product;
using EcommerceShop.Application.Product.UpdateProduct;
using MediatR;

namespace Product.Application.Product.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);

            product.Name = request.Name;
            product.Description = request.Description;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
