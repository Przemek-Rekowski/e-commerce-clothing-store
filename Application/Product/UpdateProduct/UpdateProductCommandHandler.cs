using Domain.Interfaces;
using EcommerceShop.Application.Product.UpdateProduct;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            product.Price = request.Price;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
