using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _manager.Products.GetProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDto);
        }

        [HttpPut("productId")]
        public async Task <IActionResult> UpdateProduct(Guid productId, [FromBody]UpdateProductsDto updateProductsDto)
        {
            if (updateProductsDto == null)
                return BadRequest("Product DTO object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var product = await _manager.Products.GetProductAsync(productId);
            if (product == null)
                return NotFound();

            _mapper.Map(updateProductsDto, product);
            await _manager.SaveAsync();

            return NoContent();
        }
    }
}
