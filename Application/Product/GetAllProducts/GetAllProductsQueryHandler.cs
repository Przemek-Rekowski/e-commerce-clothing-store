using AutoMapper;
using Domain.Constants;
using Domain.Interfaces.Product;
using EcommerceShop.Application.Product.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EcommerceShop.Application.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler(IMapper mapper,
        IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
    {
        public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var (products, totalCount) = await productRepository.GetAll(request.SearchPhrase,
                request.PageSize,
                request.PageNumber);
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

            var result = new PagedResult<ProductDto>(productDtos, totalCount, request.PageSize, request.PageNumber);
            return result;
        }
    }
}