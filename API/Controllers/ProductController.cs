using Application.Product.CreateProduct;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Product;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;

namespace ProductAPI.Controllers
{
    [Route("api")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var carWorkshops = _mediator.Send(new GetAllProductsQuery());
            return Ok(carWorkshops);
        }
    }
}