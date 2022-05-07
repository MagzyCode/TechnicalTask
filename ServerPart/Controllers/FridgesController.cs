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
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class FridgesController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public FridgesController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all fridges.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Fridges was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<FridgeDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFridges()
        {
            var fridges = await _manager.Fridge.GetAllFridgesAsync();
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        /// <summary>
        /// Get fridge by current guid.
        /// </summary>
        /// <param name="fridgeId"></param>
        /// <returns></returns>
        /// <response code="200">Fridge model with given guid was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("{fridgeId}")]
        [ProducesResponseType(type: typeof(FridgeDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);

            if (fridge == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge with such fridgeId"
                });

            var fridgeDto = _mapper.Map<FridgeDto>(fridge);

            return Ok(fridgeDto);
        }

        /// <summary>
        /// Get products in fridge with current guid.
        /// </summary>
        /// <param name="fridgeId">Fridge guid.</param>
        /// <returns></returns>
        /// <response code="200">Fridge products was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no fridge with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("{fridgeId}/products")]
        [ProducesResponseType(type: typeof(IEnumerable<ProductsDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFridgesProducts(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge with such fridgeId"
                });

            var products = await _manager.Fridge.GetFridgeProductsAsync(fridgeId);
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);

            return Ok(productsDto);
        }

        /// <summary>
        /// Update exists fridge.
        /// </summary>
        /// <param name="fridgeId">Updated fridge guid.</param>
        /// <param name="updateFridge">Updated fridge data.</param>
        /// <returns></returns>
        /// <response code="204">Fridge was successfully updated.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no fridge or fridge models with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPut("{fridgeId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFridge(Guid fridgeId, [FromBody] UpdateFridgeDto updateFridge)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge with such fridgeId"
                });

            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(updateFridge.ModelId);
            if (fridgeModel == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge model with such ModelId"
                });

            _mapper.Map(updateFridge, fridge);
            _manager.Fridge.UpdateFridge(fridge);

            return NoContent();
        }

        /// <summary>
        /// Delete fridge with current guid.
        /// </summary>
        /// <param name="fridgeId">Deleting frige guid.</param>
        /// <returns></returns>
        /// <response code="204">Fridge was successfully deleted.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no fridge with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpDelete("{fridgeId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge with such fridgeId"
                });

            _manager.Fridge.DeleteFridge(fridge);

            return NoContent();
        }

        /// <summary>
        /// Create fridge.
        /// </summary>
        /// <param name="creationFridgeDto">Creation fridge data.</param>
        /// <returns></returns>
        /// <response code="201">User was successfully created.</response>
        /// <response code="404">There is no fridge model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        // TODO: Проверить возвращаемый тип
        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> AddFridge([FromBody] CreationFridgeDto creationFridgeDto)
        {
            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(creationFridgeDto.ModelId);
            if (fridgeModel == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge model with such ModelId"
                });

            var fridge = _mapper.Map<Fridge>(creationFridgeDto);

            var createdGuid = _manager.Fridge.AddFridge(fridge);

            return Created($"api/fridgeProducts/{createdGuid}", createdGuid);
        }

    }
}
