using AutoMapper;
using ClientPart.ApiConnection.Services;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApiConnection.Services.AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            ApiConnection.Services.AuthenticationService authenticationService,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View(new RegistrationUserViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegistrationUserViewModel registrationUserViewModel)
        {
            if (registrationUserViewModel == null || !ModelState.IsValid)
                return BadRequest();

            return RedirectToAction("GetFridges", "Fridges");
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
            if (model == null && !ModelState.IsValid)
                return BadRequest();

            try
            {
                await Authenticate(model);
            }
            catch (Refit.ValidationApiException)
            {
                ViewData["Error"] = "Try another user name or password";
                return View("~/Views/Home/Error.cshtml");
            }
            return RedirectToAction("GetFridges", "Fridges");
        }

        private async Task Authenticate(AuthenticationUserViewModel model)
        {
            if (model == null && !ModelState.IsValid)
                return;

            var authenticationUser = _mapper.Map<AuthenticationUser>(model);
            var token = await _authenticationService.Authenticate(authenticationUser);
            var claims = new List<Claim> { new Claim("Token", token) };
            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
