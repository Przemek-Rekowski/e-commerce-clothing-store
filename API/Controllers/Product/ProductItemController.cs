using EcommerceShop.Application.Item.CreateItem;
using EcommerceShop.Application.Item.DeleteItem;
using EcommerceShop.Application.Item.GetAllItems;
using EcommerceShop.Application.Item.GetItemBySku;
using EcommerceShop.Application.Product.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Product
{
    [Route("api")]
    [ApiController]

    public class ProductItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("item")]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("item")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemsQuery query)
        {
            var items = await _mediator.Send(query);
            return Ok(items);
        }

        [HttpGet]
        [Route("item/{sku}")]
        public async Task<IActionResult> GetBySku([FromRoute] string sku)
        {
            var dto = await _mediator.Send(new GetItemBySkuQuery(sku));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("item/{sku}/delete")]
        public async Task<IActionResult> Delete([FromRoute] string sku)
        {
            var dto = await _mediator.Send(new DeleteItemCommand(sku));
            return Ok(dto);
        }
    }
}