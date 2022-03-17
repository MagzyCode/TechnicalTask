using ClientPart.ApiConnection.Services;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ClientPart.Controllers
{
    public class FridgesController : Controller
    {
        private readonly FridgesService _fridgesService;
        private readonly IMapper _mapper;

        public FridgesController(FridgesService fridgesService, IMapper mapper)
        {
            _fridgesService = fridgesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            var fridges = await _fridgesService.GetAllFridges();
            return View(fridges);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFridge(Guid id)
        {
            var updatedFridge = await _fridgesService.GetFridge(id);
            var updatedFridgeModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            return View(updatedFridgeModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFridge(Guid id, UpdatedFridgeViewModel updatedFridge)
        {
            await _fridgesService.UpdateFridge(id, updatedFridge);
            return RedirectToAction("GetFridges", "Fridges");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            await _fridgesService.DeleteFridge(id);
            return RedirectToAction("GetFridges", "Fridges");
        }



    }
}
