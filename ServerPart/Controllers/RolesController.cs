using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.ErrorModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public RolesController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get existing roles.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Roles was successfully received.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _manager.Roles.GetRolesAsync();
            return Ok(roles);
        }
    }
}
