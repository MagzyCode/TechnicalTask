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
        public async Task<IActionResult> AddFridge([FromBody])
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(creationFridgeProduct.FridgeId);
            if (fridge == null)
                return NotFound("There is no fridge object with such guid.");

            var product = await _manager.Products.GetProductAsync(creationFridgeProduct.ProductId);
            if (product == null)
                return NotFound("There is no product object with such guid.");

            var fridgeProduct = _mapper.Map<FridgeProducts>(creationFridgeProduct);
            var createdGuid = _manager.FridgeProducts.AddProductInFridge(fridgeProduct);
            await _manager.SaveAsync();
            var fridgeProductToReturn = _mapper.Map<FridgeProductsDto>(await _manager.FridgeProducts.GetFridgeProductAsync(createdGuid));

            return CreatedAtRoute("FridgeProductById", new { fridgeProductId = createdGuid }, fridgeProductToReturn);
        }

    }
}
