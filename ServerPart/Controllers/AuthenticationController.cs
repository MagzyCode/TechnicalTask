﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerPart.ActionFilters;
using ServerPart.Contracts.AuthenticationManagerContracts;
using ServerPart.Models;
using ServerPart.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(IMapper mapper, UserManager<User> userManager, 
            IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody]UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
                return Unauthorized();
            return Ok( new { Token = await _authManager.CreateToken() });
        }
    }
}
