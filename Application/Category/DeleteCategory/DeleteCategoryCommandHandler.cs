﻿using Domain.Interfaces.Product;
using MediatR;

namespace EcommerceShop.Application.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
           /* var category = await _repository.GetById(request.Id!);

            if(category != null)
            {
                await _repository.Delete(category);
            }
           */
            return Unit.Value;
        }
    }

}