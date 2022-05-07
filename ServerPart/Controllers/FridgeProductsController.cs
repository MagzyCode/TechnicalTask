using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models;
using ServerPart.Models.DTOs;
using ServerPart.Models.ErrorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridgeProducts")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
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
        /// <response code="200">Fridges products was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<FridgeProductsDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
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
        /// <response code="200">Stored procedure was successfully executed.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("procedure")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CallServerProcedure()
        {
            await _manager.FridgeProducts.CallStoredProcedureAsync();

            return Ok();
        }

        /// <summary>
        /// Get fridge product by current guid.
        /// </summary>
        /// <param name="fridgeProductId">Fridge product guid.</param>
        /// <returns></returns>
        /// <response code="200">Fridges product with gived guid was successfully received.</response>
        /// <response code="400">There is no fridge product object with such guid.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("{fridgeProductId}", Name = "FridgeProductById")]
        [ProducesResponseType(type: typeof(FridgeProductsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
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
        /// <response code="201">Fridges models was successfully created.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        // TODO: Проверить, какой тип возвращается
        [ProducesResponseType(type: typeof(FridgeProductsDto), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> AddFridgeProduct([FromBody] CreationFridgeProductDto creationFridgeProduct)
        {
            var product = await _manager.Products.GetProductAsync(creationFridgeProduct.ProductId);
            if (product == null)
                return NotFound("There is no product object with such guid.");

            var fridge = await _manager.Fridge.GetFridgeAsync(creationFridgeProduct.FridgeId);
            if (fridge == null)
                return NotFound("There is no fridge object with such guid.");

            var fridgeProductInFridge = await _manager.FridgeProducts.GetFridgeProductByGuidsAsync(
               fridgeId: creationFridgeProduct.FridgeId,
               productId: creationFridgeProduct.ProductId);

            if (fridgeProductInFridge != null)
                return NotFound("Can't create duplicate fridge product.");

            var fridgeProduct = _mapper.Map<FridgeProducts>(creationFridgeProduct);
            var createdGuid = _manager.FridgeProducts.AddProductInFridge(fridgeProduct);

            var fridgeProductToReturn = await _manager.FridgeProducts.GetFridgeProductAsync(createdGuid);
            var fridgeProductDtoToReturn = _mapper.Map<FridgeProductsDto>(fridgeProductToReturn);

            return CreatedAtRoute("FridgeProductById", new { fridgeProductId = createdGuid }, fridgeProductDtoToReturn);
        }

        /// <summary>
        /// Delete product from fridge.
        /// </summary>
        /// <param name="fridgeProductId">Deleting fridge product guid.</param>
        /// <returns></returns>
        /// <response code="204">Fridge product was successfully deleted.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpDelete("{fridgeProductId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFridgeProduct(Guid fridgeProductId)
        {
            var fridgeProduct = await _manager.FridgeProducts.GetFridgeProductAsync(fridgeProductId);
            if (fridgeProduct == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge product with such fridgeProductId."
                });

            _manager.FridgeProducts.DeleteFridgeProduct(fridgeProduct);

            return NoContent();
        }

        /// <summary>
        /// Update fridge product.
        /// </summary>
        /// <param name="fridgeProductId">Fridge product guid.</param>
        /// <param name="updateFridgeProductDto">Updated fridge product DTO model.</param>
        /// <returns></returns>
        /// <response code="204">Fridge product was successfully updated.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPut("{fridgeProductId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> UpdateFridgeProduct(Guid fridgeProductId, [FromBody] UpdateFridgeProductDto updateFridgeProductDto)
        {
            var fridgeProduct = await _manager.FridgeProducts.GetFridgeProductAsync(fridgeProductId);
            if (fridgeProduct == null)
                return NotFound("There is no fridge product with given guid.");

            var product = await _manager.Products.GetProductAsync(updateFridgeProductDto.ProductId);
            if (product == null)
                return NotFound("There is no product object with such guid.");

            var fridge = await _manager.Fridge.GetFridgeAsync(updateFridgeProductDto.FridgeId);
            if (fridge == null)
                return NotFound("There is no fridge object with such guid.");

            var fridgeProductInFridge = await _manager.FridgeProducts.GetFridgeProductByGuidsAsync(
               fridgeId: updateFridgeProductDto.FridgeId,
               productId: updateFridgeProductDto.ProductId);

            if (fridgeProductInFridge == null)
                return NotFound("Can't update non-existent fridge product.");

            // TODO: Проверить обновляются ли данные
            _mapper.Map(updateFridgeProductDto, fridgeProductInFridge);
            _manager.FridgeProducts.UpdateFridgeProduct(fridgeProductInFridge);

            return NoContent();
        }

    }
}
