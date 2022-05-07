using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerPart.Contracts.AuthenticationManagerContracts;
using ServerPart.Contracts.RepositoryManagerContracts;
using ServerPart.Models.DTOs;
using ServerPart.Models.ErrorModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IAuthenticationManager _authenticationManager;

        public RolesController(IRepositoryManager manager, IAuthenticationManager authenticationManager)
        {
            _manager = manager;
            _authenticationManager = authenticationManager;
        }

        /// <summary>
        /// Get existing roles.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Roles was successfully received.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpGet("roles")]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _manager.Roles.GetRolesAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Get user role by user credentials.
        /// </summary>
        /// <param name="user">User authentication model.</param>
        /// <returns></returns>
        /// <response code="200">User role was successfully received.</response>
        /// <response code="401">User credential not pass.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPost("user/role")]
        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserRole(UserForAuthenticationDto user)
        {
            var isValid = await _authenticationManager.ValidateUser(user);

            if (!isValid)
                return Unauthorized(new ErrorDetails()
                {
                    StatusCode = 401,
                    Message = "User credentials are wrong for get user role."
                });

            var role = await _authenticationManager.GetUserRoleAsync(user.UserName);

            return Ok(role);
        }
     }
}
