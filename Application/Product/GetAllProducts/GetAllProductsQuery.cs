using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}