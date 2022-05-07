using AutoMapper;
using ClientPart.ApiConnection.Services;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApiConnection.Services.AuthenticationService _authenticationService;
        private readonly RolesService _rolesService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            ApiConnection.Services.AuthenticationService authenticationService,
            RolesService rolesService,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _rolesService = rolesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _rolesService.GetRolesAsync();

            return View(new RegistrationUserViewModel()
            {
                Roles = roles.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationUserViewModel registrationUserViewModel)
        {
            if (registrationUserViewModel == null || !ModelState.IsValid)
                return BadRequest();

            var registrationUser = _mapper.Map<User>(registrationUserViewModel);
            await _authenticationService.RegisterUserAsync(registrationUser);

            var userInSystem = new AuthenticationUserViewModel()
            {
                UserName = registrationUser.UserName,
                Password = registrationUser.Password
            };

            await Authenticate(userInSystem);

            return RedirectToAction("FridgesList", "Fridges");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new AuthenticationUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationUserViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            await Authenticate(model);

            return RedirectToAction("FridgesList", "Fridges");
        }

        private async Task Authenticate(AuthenticationUserViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return;

            var authenticationUser = _mapper.Map<AuthenticationUser>(model);
            var token = await _authenticationService.AuthenticateAsync(authenticationUser);

            var role = await _authenticationService.GetUserRoleAsync(authenticationUser);

            var claims = new List<Claim>
            {
                new Claim("Token", token),
                new Claim(ClaimTypes.Role, role.Replace("\"", ""))
            };

            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
