using Application.Product.Dtos;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}