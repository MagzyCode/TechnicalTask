using ClientPart.ApiConnection.Services;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Register()
        {
            return View();
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

            // TODO: В случае неправильных данных выкидывает ошибку
            var token = await _authenticationService.Authenticate(model);
            // ViewBag.Token = token;
            //HttpContext.Response.HttpContext.Response.Headers.Add("Autorization", $"Bearer {token}");
            // Исправить на перевод на начальную страницу пользователя
            return RedirectToAction("GetFridges", "Fridges");
        }


    }
}
