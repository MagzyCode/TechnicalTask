﻿using AutoMapper;
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
        public async Task<IActionResult> GetAllFridges()
        {
            var fridges = await _manager.Fridge.GetAllFridgesAsync();
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{fridgeId}")]
        public async Task<IActionResult> GetFridge(Guid fridgeId)
        {
            var fridge = await _manager.Fridge.GetFridgeAsync(fridgeId);
            if (fridge == null)
                return NotFound();
            var fridgeDto = _mapper.Map<FridgeDto>(fridge);
            return Ok(fridgeDto);
        }

        [HttpGet("{fridgeId}/products")]
        public async Task<IActionResult> GetFridgesProducts(Guid fridgeId)
        {
            var products = await _manager.Fridge.GetFridgeProductsAsync(fridgeId);
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDto);
        }

        
    }
}