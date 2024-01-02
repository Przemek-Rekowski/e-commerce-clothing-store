using Application.Product.CreateProduct;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
    }
}