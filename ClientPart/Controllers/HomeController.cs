using ClientPart.ApiConnection.Services;
using ClientPart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class HomeController : Controller
    {
        private readonly FridgeProductsService _fridgeProductsService;

        public HomeController(FridgeProductsService fridgeProductsService)
        {
            _fridgeProductsService = fridgeProductsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Procedure()
        {
            await _fridgeProductsService.CallServerProcedureAsync();

            return RedirectToAction("FridgesList", "Fridges");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
