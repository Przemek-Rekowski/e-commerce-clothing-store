using Domain.Constants;
using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<PagedResult<ProductDto>>
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}