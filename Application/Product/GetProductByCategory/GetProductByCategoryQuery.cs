using Application.Product.Dtos;
using MediatR;

namespace Product.Application.Product.GetProductById
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