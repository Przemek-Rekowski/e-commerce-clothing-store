using Application.ProductImages.CreateImage;
using Application.ProductImages.DelateImageByProduct;
using Application.ProductImages.GetImageByProduct;
using EcommerceShop.Application.Image.DeleteImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Image
{
    [Route("api/product")]
    [ApiController]

    public class ProductImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("image")]
        public async Task<IActionResult> Create([FromBody] CreateProductImageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("{productId}/image")]
        public async Task<IActionResult> GetByProduct([FromRoute] int productId)
        {
            var dto = await _mediator.Send(new GetImagesByProductQuery(productId));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("image/{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var dto = await _mediator.Send(new DeleteProductImageCommand(id));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{productId}/image")]
        public async Task<IActionResult> DeleteByProduct([FromRoute] int productId)
        {
            var dto = await _mediator.Send(new DelateImageByProductCommand(productId));
            return Ok(dto);
        }
    }
}