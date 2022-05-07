using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using ServerPart.Models.ErrorModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/fridgeModels")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class FridgeModelsController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public FridgeModelsController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all fridge models.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Fridges models was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<FridgeModelDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFridgeModels()
        {
            var fridgeModel = await _manager.FridgeModel.GetAllFridgeModelsAsync();
            var fridgeModelDto = _mapper.Map<IEnumerable<FridgeModelDto>>(fridgeModel);

            return Ok(fridgeModelDto);
        }

        /// <summary>
        /// Get fridge model by current guid.
        /// </summary>
        /// <param name="fridgeModelId">Fridge model guid.</param>
        /// <returns></returns>
        /// <response code="200">Fridges model with given guid was successfully received.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="404">There is no fridge model with given guid.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("{fridgeModelId}")]
        [ProducesResponseType(type: typeof(FridgeModelDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFridgeModel(Guid fridgeModelId)
        {
            var fridgeModel = await _manager.FridgeModel.GetFridgeModelAsync(fridgeModelId);

            if (fridgeModel == null)
                return NotFound(new ErrorDetails()
                {
                    StatusCode = 404,
                    Message = "There is no fridge model with such fridgeModelId"
                });

            var fridgeModelDto = _mapper.Map<FridgeModelDto>(fridgeModel);

            return Ok(fridgeModelDto);
        }


    }
}
