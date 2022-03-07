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
        public IActionResult GetProducts()
        {
            var products = _manager.Products.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDto);
        }

        [HttpPut("productId")]
        public IActionResult UpdateProduct(Guid productId, [FromBody]UpdateProductsDto updateProductsDto)
        {
            if (updateProductsDto == null)
                return BadRequest("Product DTO object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var product = _manager.Products.GetProduct(productId);
            if (product == null)
                return NotFound();

            _mapper.Map(updateProductsDto, product);
            _manager.Save();

            return NoContent();
        }
    }
}
