using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using ServerPart.Models.ErrorModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get products.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Products models was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<ProductsDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _manager.Products.GetProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);

            return Ok(productsDto);
        }

        /// <summary>
        /// Get single product in database with current guid.
        /// </summary>
        /// <param name="productId">Product guid.</param>
        /// <returns></returns>
        /// <response code="200">Product model with given guid was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("{productId}")]
        [ProducesResponseType(type: typeof(ProductsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _manager.Products.GetProductAsync(productId);
            var productDto = _mapper.Map<ProductsDto>(product);

            return Ok(productDto);
        }

        /// <summary>
        /// Update existing product.
        /// </summary>
        /// <param name="productId">Updated product guid.</param>
        /// <param name="updateProductsDto">Updated product data.</param>
        /// <returns></returns>
        /// <response code="204">User was successfully updated.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no product with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPut("{productId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductsDto updateProductsDto)
        {
            var product = await _manager.Products.GetProductAsync(productId);
            if (product == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no product with such productId."
                });

            _mapper.Map(updateProductsDto, product);

            _manager.Products.UpdateProduct(product);

            return NoContent();
        }
    }
}
