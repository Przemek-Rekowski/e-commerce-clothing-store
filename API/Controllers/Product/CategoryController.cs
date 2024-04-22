using Application.Category.CreateCategory;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EcommerceShop.Application.Category.UpdateCategory;
using EcommerceShop.Application.Category.DeleteCategory;
using EcommerceShop.Application.Category.GetAllCategories;

namespace API.Controllers.Product
{
    [Route("api/category")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command, [FromRoute] int id)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var dto = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(dto);
        }
    }
}