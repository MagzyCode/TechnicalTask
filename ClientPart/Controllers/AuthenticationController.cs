using ClientPart.ApiConnection.Services;
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

        public AuthenticationController(ApiConnection.Services.AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Register()
        {
            return View();
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
            // HttpContext.Session.Clear();
            return View(new AuthenticationUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationUserViewModel model)
        {
            if (model == null && !ModelState.IsValid)
                return BadRequest();
            await Authenticate(model);
            // TODO: В случае неправильных данных выкидывает ошибку
            //var token = await _authenticationService.Authenticate(model);
            // HttpContext.Session.SetString(nameof(token), token);
            // HttpContext.Request.Headers.Add("Authorization", "Bearer " + token); //.SetString(nameof(token), token);
            return RedirectToAction("GetFridges", "Fridges");
        }

        private async Task Authenticate(AuthenticationUserViewModel model)
        {
            var token = await _authenticationService.Authenticate(model);
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim("Token", token)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        //private async Task AuthenticationUser(AuthenticationUserViewModel user)
        //{

        //}


    }
}
