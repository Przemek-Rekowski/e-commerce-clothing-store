using Application.Product.CreateProduct;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Product;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using Product.Application.Product.GetProductById;
using EcommerceShop.Application.Product.UpdateProduct;

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
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
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

        [HttpGet]
        [Route("product/{id})")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var dto = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(dto);
        }

        [HttpPost]
        [Route("product/{id}/edit")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}