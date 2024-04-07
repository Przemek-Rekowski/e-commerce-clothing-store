using Domain.Interfaces.Image;
using EcommerceShop.Application.Image.DeleteImage;
using EcommerceShop.Application.Item.DeleteItem;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
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

            if(item != null)
            {
                await _repository.Delete(item);
            }

            return Unit.Value;
        }
    }
}
