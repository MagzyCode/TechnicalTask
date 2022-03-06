using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("procedure")]
        public IActionResult CallServerProcedure()
        {
            _manager.FridgeProducts.CallStoredProcedure();
            _manager.Save();

            var fridgeProducts = _manager.FridgeProducts.GetAllFridgesProducts();
            var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductsDto>>(fridgeProducts);

            return Ok(fridgeProductsDto);
        }

        [HttpGet("{fridgeProductId}", Name = "FridgeProductById")]
        public IActionResult GetFridgeProductById(Guid fridgeProductId)
        {
            var fridgeProduct = _manager.FridgeProducts.GetFridgeProduct(fridgeProductId);
            if (fridgeProduct == null)
                return BadRequest("There is no fridge product object with such guid.");

            var fridgeProductDto = _mapper.Map<FridgeProductsDto>(fridgeProduct);
            return Ok(fridgeProductDto);
        }

        [HttpPost]
        public IActionResult AddProductInFridge([FromBody]CreationFridgeProductDto creationFridgeProduct)
        {
            if (creationFridgeProduct == null)
                return BadRequest("Object creationFridgeProduct is null");

            var fridge = _manager.Fridge.GetFridge(creationFridgeProduct.FridgeId);
            if (fridge == null)
                return NotFound("There is no fridge object with such guid.");

            var product = _manager.Products.GetProduct(creationFridgeProduct.ProductId);
            if (product == null)
                return NotFound("There is no product object with such guid.");

            var fridgeProduct = _mapper.Map<FridgeProducts>(creationFridgeProduct);
            var createdGuid = _manager.FridgeProducts.AddProductInFridge(fridgeProduct);
            _manager.Save();
            var fridgeProductToReturn = _mapper.Map<FridgeProductsDto>(_manager.FridgeProducts.GetFridgeProduct(createdGuid));

            return CreatedAtRoute("FridgeProductById", new { fridgeProductId = createdGuid }, fridgeProductToReturn);
        }
    }
}
