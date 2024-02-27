using EcommerceShop.Application.Product.Dtos;
using MediatR;

namespace EcommerceShop.Application.Product.GetProductByCategory
{
    public class GetProductByCategoryQuery : IRequest<ProductDto>
    {
        public int CategoryId { get; set; }

        public GetProductByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}