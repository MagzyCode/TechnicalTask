using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridges")]
    [ApiController]
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
        [HttpGet]
        [Authorize]
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
        [HttpGet("{fridgeId}")]
        [Authorize]
        public async Task<IActionResult> GetFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);

            if (fridge == null)
                return NotFound();

            var fridgeDto = _mapper.Map<FridgeDto>(fridge);

            return Ok(fridgeDto);
        }

        /// <summary>
        /// Get products in fridge with current guid.
        /// </summary>
        /// <param name="fridgeId">Fridge guid.</param>
        /// <returns></returns>
        [HttpGet("{fridgeId}/products")]
        [Authorize]
        public async Task<IActionResult> GetFridgesProducts(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();

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
        [HttpPut("{fridgeId}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateFridge(Guid fridgeId, [FromBody]UpdateFridgeDto updateFridge)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();

            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(updateFridge.ModelId);
            if (fridgeModel == null)
                return NotFound();

            _mapper.Map(updateFridge, fridge);
            await _manager.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete fridge with current guid.
        /// </summary>
        /// <param name="fridgeId">Deleting frige guid.</param>
        /// <returns></returns>
        [HttpDelete("{fridgeId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();

            _manager.Fridge.DeleteFridge(fridge);
            await _manager.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Create fridge.
        /// </summary>
        /// <param name="creationFridgeDto">Creation fridge data.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddFridge([FromBody]CreationFridgeDto creationFridgeDto)
        {
            var model = await _manager.FridgeModel.GetFridgeModelAsync(creationFridgeDto.ModelId);
            if (model == null)
                return NotFound();

            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(creationFridgeDto.ModelId);
            if (fridgeModel == null)
                return NotFound();

            var fridge = _mapper.Map<Fridge>(creationFridgeDto);

            var createdGuid = _manager.Fridge.AddFridge(fridge);
            await _manager.SaveAsync();

            return Created($"api/fridgeProducts/{createdGuid}", createdGuid);
        }

    }
}
