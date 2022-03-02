using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.RepositoryManagerContracts;
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

        public FridgesController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllFridges()
        {
            var fridges = _manager.Fridge.FindAll();
            var fridgesDto = _mapper.Map<IQueryable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }
    }
}
