using Application.Product;
using MediatR;

namespace EcommerceShop.Application.Product.UpdateProduct
{
    public class UpdateProductCommand : ProductDto, IRequest<Unit>
    {

    }
}