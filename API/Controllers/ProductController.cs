﻿using EcommerceShop.Application.Product.CreateProduct;
using EcommerceShop.Application.Product.DeleteProduct;
using EcommerceShop.Application.Product.GetAllProducts;
using EcommerceShop.Application.Product.GetProductByCategory;
using EcommerceShop.Application.Product.GetProductsById;
using EcommerceShop.Application.Product.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dto = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(dto);
        }

        [HttpGet]
        [Route("product/category/{id}")]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {
            var dto = await _mediator.Send(new GetProductByCategoryQuery(categoryId));
            return Ok(dto);
        }

        [HttpPost]
        [Route("product/{id}/edit")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command, [FromRoute] int id)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("product/{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}