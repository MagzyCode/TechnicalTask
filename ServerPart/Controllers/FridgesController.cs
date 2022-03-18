using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpGet/*, Authorize*/]
        public async Task<IActionResult> GetAllFridges()
        {
            var fridges = await _manager.Fridge.GetAllFridgesAsync();
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{fridgeId}")/*, Authorize*/]
        public async Task<IActionResult> GetFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();
            var fridgeDto = _mapper.Map<FridgeDto>(fridge);
            return Ok(fridgeDto);
        }

        [HttpGet("{fridgeId}/products")/*, Authorize*/]
        public async Task<IActionResult> GetFridgesProducts(Guid fridgeId)
        {
            var products = await _manager.Fridge.GetFridgeProductsAsync(fridgeId);
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDto);
        }

        [HttpPut("{fridgeId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateFridge(Guid fridgeId, [FromBody]UpdateFridgeDto updateFridge)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();

            _mapper.Map(updateFridge, fridge);
            await _manager.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{fridgeId}")/*, Authorize*/]
        public async Task<IActionResult> DeleteFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();

            _manager.Fridge.DeleteFridge(fridge);
            await _manager.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddFridge([FromBody]CreationFridgeDto creationFridgeDto)
        {
            var model = await _manager.FridgeModel.GetFridgeModelAsync(creationFridgeDto.ModelId);
            if (model == null)
                return NotFound();

            var fridge = _mapper.Map<Fridge>(creationFridgeDto);
            var createdGuid = _manager.Fridge.AddFridge(fridge);
            await _manager.SaveAsync();
            var result = await _manager.Fridge.GetFridgeAsync(createdGuid);
            var fridgeDtoToReturn = _mapper.Map<FridgeDto>(await _manager.Fridge.GetFridgeAsync(createdGuid));

            return CreatedAtRoute("FridgeProductById", new { fridgeProductId = createdGuid }, fridgeDtoToReturn);
        }

    }
}
