using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.UpdateProduct
{
    public class UpdateProductCommand : UpdateProductDto, IRequest<Unit>
    {
        public int Id;
    }
}