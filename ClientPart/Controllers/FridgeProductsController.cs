using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class FridgeProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
