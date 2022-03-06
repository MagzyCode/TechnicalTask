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

        [HttpGet]
        public IActionResult GetAllFridges()
        {
            var fridges = _manager.Fridge.GetAllFridges();
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{fridgeId}")]
        public IActionResult GetFridge(Guid fridgeId)
        {
            var fridge = _manager.Fridge.GetFridge(fridgeId);
            if (fridge == null)
                return NotFound();
            var fridgeDto = _mapper.Map<FridgeDto>(fridge);
            return Ok(fridgeDto);
        }

        [HttpGet("{fridgeId}/products")]
        public IActionResult GetFridgesProducts(Guid fridgeId)
        {
            var products = _manager.Fridge.GetFridgeProducts(fridgeId);
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDto);
        }

        
    }
}
