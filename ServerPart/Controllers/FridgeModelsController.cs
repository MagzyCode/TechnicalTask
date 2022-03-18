﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridgeModels")]
    [ApiController]
    public class FridgeModelsController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public FridgeModelsController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridgeModels()
        {
            var fridgeModel = await _manager.FridgeModel.GetAllFridgeModelsAsync();
            var fridgeModelDto = _mapper.Map<IEnumerable<FridgeModelDto>>(fridgeModel);
            return Ok(fridgeModelDto);
        }

        [HttpGet("{fridgeModelId}")]
        public async Task<IActionResult> GetFridgeModel(Guid fridgeModelId)
        {
            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(fridgeModelId);
            if (fridgeModel == null)
                return NotFound();
            var fridgeModelDto = _mapper.Map<FridgeModelDto>(fridgeModel);
            return Ok(fridgeModelDto);
        }


    }
}