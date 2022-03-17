using ClientPart.ApiConnection.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class FridgesController : Controller
    {
        private readonly FridgesService _fridgesService;

        public FridgesController(FridgesService fridgesService)
        {
            _fridgesService = fridgesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            string token = ViewBag.Token;
            HttpContext.Request.Headers.Add("Authorization", token);
            var fridges = await _fridgesService.GetAllFridges();
            return View(fridges);
        }
    }
}
