using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.RepositoryManagerContracts;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public RolesController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _manager.Roles.GetRolesAsync();
            return Ok(roles);
        }
    }
}
