using Domain.Constants;
using EcommerceShop.Application.Product.Dtos;
using MediatR;

public class GetProductByCategoryQuery : IRequest<PagedResult<ProductDto>>
{
    public GetProductByCategoryQuery() { }

    public GetProductByCategoryQuery(string categoryName)
    {
        CategoryName = categoryName;
    }

    public string CategoryName { get; set; } = default!;
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
