using Domain.Interfaces.Product;
using EcommerceShop.Application.Image.DeleteImage;
using EcommerceShop.Application.Item.DeleteItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductImages.DeleteImage
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _repository;
        public DeleteProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetById(request.Id!);

            await _repository.Delete(item);

            return Unit.Value;
        }
    }
}
