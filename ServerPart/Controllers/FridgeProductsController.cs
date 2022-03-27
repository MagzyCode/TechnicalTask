using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridgeProducts")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public FridgeProductsController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all fridge products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFridgesProducts()
        {
            var fridgeProducts = await _manager.FridgeProducts.GetAllFridgesProductsAsync();
            var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductsDto>>(fridgeProducts);

            return Ok(fridgeProductsDto);
        }

        /// <summary>
        /// Call stored procedure for this task.
        /// </summary>
        /// <returns></returns>
        [HttpGet("procedure")]
        public async Task<IActionResult> CallServerProcedure()
        {
            await _manager.FridgeProducts.CallStoredProcedureAsync();
            await _manager.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Get fridge product by current guid.
        /// </summary>
        /// <param name="fridgeProductId">Fridge product guid.</param>
        /// <returns></returns>
        [HttpGet("{fridgeProductId}", Name = "FridgeProductById")]
        [Authorize]
        public async Task<IActionResult> GetFridgeProductById(Guid fridgeProductId)
        {
            var fridgeProduct = await _manager.FridgeProducts.GetFridgeProductAsync(fridgeProductId);

            if (fridgeProduct == null)
                return BadRequest("There is no fridge product object with such guid.");

            var fridgeProductDto = _mapper.Map<FridgeProductsDto>(fridgeProduct);

            return Ok(fridgeProductDto);
        }

        /// <summary>
        /// Add or complement fridge product.
        /// </summary>
        /// <param name="creationFridgeProduct">Adding fridge model data.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddFridgeProduct([FromBody]CreationFridgeProductDto creationFridgeProduct)
        {
            var product = await _manager.Products.GetProductAsync(creationFridgeProduct.ProductId);
            if (product == null)
                return NotFound("There is no product object with such guid.");

            var fridge = await _manager.Fridge.GetFridgeAsync(creationFridgeProduct.FridgeId);
            if (fridge == null)
                return NotFound("There is no fridge object with such guid.");

            var fridgeProducts = await _manager.FridgeProducts.GetAllFridgesProductsAsync();
            var fridgeProductInFridge = fridgeProducts
                .FirstOrDefault(x => x.FridgeId.Equals(creationFridgeProduct.FridgeId) && x.ProductId.Equals(creationFridgeProduct.ProductId));
            
            var fridgeProduct = _mapper.Map<FridgeProducts>(creationFridgeProduct);
            var createdGuid = new Guid();
            
            if (fridgeProductInFridge == null)
            {
                createdGuid = _manager.FridgeProducts.AddProductInFridge(fridgeProduct);
            }
            else
            {
                _manager.FridgeProducts.UpdateFridgeProduct(fridgeProduct);
                createdGuid = fridgeProduct.Id;
            }
            
            await _manager.SaveAsync();
            var fridgeProductToReturn = _mapper.Map<FridgeProductsDto>(await _manager.FridgeProducts.GetFridgeProductAsync(createdGuid));

            return CreatedAtRoute("FridgeProductById", new { fridgeProductId = createdGuid }, fridgeProductToReturn);
        }

        /// <summary>
        /// Delete product from fridge.
        /// </summary>
        /// <param name="fridgeProductId">Deleting fridge product guid.</param>
        /// <returns></returns>
        [HttpDelete("{fridgeProductId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteFridgeProduct(Guid fridgeProductId)
        {
            var fridgeProduct = await _manager.FridgeProducts.GetFridgeProductAsync(fridgeProductId);
            if (fridgeProduct == null)
                return NotFound();

            _manager.FridgeProducts.DeleteFridgeProduct(fridgeProduct);
            await _manager.SaveAsync();

            return NoContent();
        }
    }
}
