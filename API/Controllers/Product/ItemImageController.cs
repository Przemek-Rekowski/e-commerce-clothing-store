using Application.ItemImages.CreateItemImage;
using Application.ProductImages.GetImageByProduct;
using EcommerceShop.Application.ItemImages.DeleteImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Item
{
    [Route("api")]
    [ApiController]

    public class ItemImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("item/image")]
        public async Task<IActionResult> Create([FromBody] CreateItemImageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("item/{itemSku}/image")]
        public async Task<IActionResult> GetByItem([FromRoute] string itemSku)
        {
            var dto = await _mediator.Send(new GetImagesByItemQuery(itemSku));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("item/image/{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var dto = await _mediator.Send(new DeleteItemImageCommand(id));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("item/{itemSku}/image")]
        public async Task<IActionResult> DeleteByItem([FromRoute] string itemSku)
        {
            var dto = await _mediator.Send(new DelateImageByItemCommand(itemSku));
            return Ok(dto);
        }
    }
}