using AutoMapper;
using Domain.Constants;
using Domain.Interfaces.Product;
using EcommerceShop.Application.Product.Dtos;
using EcommerceShop.Application.Product.GetAllProducts;
using MediatR;

namespace EcommerceShop.Application.Product.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler(IMapper mapper,
     IProductRepository productRepository) : IRequestHandler<GetProductByCategoryQuery, PagedResult<ProductDto>>
    {
        public async Task<PagedResult<ProductDto>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var (products, totalCount) = await productRepository.GetByCategory(request.CategoryName, request.SearchPhrase,
                request.PageSize,
                request.PageNumber);
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

            var result = new PagedResult<ProductDto>(productDtos, totalCount, request.PageSize, request.PageNumber);
            return result;
        }
    }
}