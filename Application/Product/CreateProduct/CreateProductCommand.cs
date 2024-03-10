using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.CreateProduct
{
    public class CreateProductCommand : CreateProductDto, IRequest<Unit>
    {
    }
}