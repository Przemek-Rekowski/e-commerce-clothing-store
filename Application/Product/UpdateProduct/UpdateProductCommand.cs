﻿using Application.Product;
using MediatR;

namespace EcommerceShop.Application.Product.UpdateProduct
{
    public class UpdateProductCommand : ProductDto, IRequest<Unit>
    {
        public int Id;

        public UpdateProductCommand(int id)
        {
            Id = id;
        }
    }
}