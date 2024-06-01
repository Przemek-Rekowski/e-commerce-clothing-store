using Domain.Constants;
using EcommerceShop.Application.Item.CreateItem;
using EcommerceShop.Application.Item.DeleteItem;
using EcommerceShop.Application.Item.GetAllItems;
using EcommerceShop.Application.Item.GetItemBySku;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Product
{
    [Route("api/item")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemsQuery query)
        {
            var items = await _mediator.Send(query);
            return Ok(items);
        }

        [HttpGet]
        [Route("/{sku}")]
        public async Task<IActionResult> GetBySku([FromRoute] string sku)
        {
            var dto = await _mediator.Send(new GetItemBySkuQuery(sku));
            return Ok(dto);
        }

        [HttpDelete]
        [Route("/delete/{sku}")]
        public async Task<IActionResult> Delete([FromRoute] string sku)
        {
            var dto = await _mediator.Send(new DeleteItemCommand(sku));
            return Ok(dto);
        }
    }
}