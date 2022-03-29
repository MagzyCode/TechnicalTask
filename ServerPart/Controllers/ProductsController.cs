﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Get products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _manager.Products.GetProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);

            return Ok(productsDto);
        }

        /// <summary>
        /// Update existing product.
        /// </summary>
        /// <param name="productId">Updated product guid.</param>
        /// <param name="updateProductsDto">Updated product data.</param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        [Authorize(Roles = "Administrator")]
        [ValidationFilter]
        public async Task <IActionResult> UpdateProduct(Guid productId, [FromBody]UpdateProductsDto updateProductsDto)
        {
            var product = await _manager.Products.GetProductAsync(productId);
            if (product == null)
                return NotFound();

            _mapper.Map(updateProductsDto, product);
            await _manager.SaveAsync();

            return NoContent();
        }
    }
}
