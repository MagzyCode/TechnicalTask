using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.AuthenticationManagerContracts;
using ServerPart.Models;
using ServerPart.Models.Documentation.Swagger;
using ServerPart.Models.DTOs;
using ServerPart.Models.ErrorModel;
using Swashbuckle.Examples;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(IMapper mapper, UserManager<User> userManager,
            IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        /// <summary>
        /// Registrate user in system. 
        /// </summary>
        /// <param name="userForRegistration">Registration user.</param>
        /// <response code="201">User was successfully registered.</response>
        /// <response code="400">Incoming model is null or validation not pass.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPost("registration")]
        [SwaggerRequestExample(requestType: typeof(RegisterUserExample), examplesProviderType: typeof(RegisterUserExample))]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var message = new StringBuilder();

                foreach (var item in result.Errors)
                    message.AppendLine(item.Description);

                return BadRequest(new ErrorDetails()
                {
                    StatusCode = 400,
                    Message = message.ToString()
                });
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        /// <summary>
        /// Authenticate user in system.
        /// </summary>
        /// <param name="user">Authenticate data of user.</param>
        /// <returns></returns>
        /// <response code="200">Authentication was successfully pass.</response>
        /// <response code="401">Should be authorize.</response>
        /// <response code="500">Something going wrong on server.</response>
        [HttpPost("authentication/login")]
        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ErrorDetails), statusCode: StatusCodes.Status500InternalServerError)]
        [ValidationFilter]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
                return Unauthorized(new ErrorDetails()
                {
                    StatusCode = 401,
                    Message = "Authenticate was failed. Try another user name or password"
                });

            var token = await _authManager.CreateToken();

            return Ok(token);
        }
    }
}
