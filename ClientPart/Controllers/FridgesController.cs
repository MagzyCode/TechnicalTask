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
        private readonly FridgeModelService _fridgeModelService;
        private readonly ProductsService _productsService;
        private readonly FridgeProductsService _fridgeProductsService;
        private readonly IMapper _mapper;

        public FridgesController(
            FridgesService fridgesService, 
            FridgeModelService modelService, 
            ProductsService productsService,
            FridgeProductsService fridgeProductsService,
            IMapper mapper)
        {
            _fridgesService = fridgesService;
            _mapper = mapper;
            _fridgeModelService = modelService;
            _productsService = productsService;
            _fridgeProductsService = fridgeProductsService;
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
            var updatedFridgeViewModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            // all
            var fridgeProducts = await _fridgeProductsService.GetFridgesProducts();
            var fridgeProductsById = fridgeProducts
                .Where(x => x.FridgeId.Equals(id))
                .ToList();
            var products = await _productsService.GetProducts();
            var productsViewModel = _mapper.Map<IEnumerable<AddProductInFridgeViewModel>>(products);
            foreach (AddProductInFridgeViewModel item in productsViewModel)
            {
                if (fridgeProductsById.Any(x => x.ProductId.Equals(item.Id)))
                {
                    item.IsChecked = true;
                    item.Quantity = fridgeProductsById.First(x => x.ProductId.Equals(item.Id)).Quantity;
                }
            }
                
                    
            updatedFridgeViewModel.FridgeProducts = productsViewModel.ToList();
            return View(updatedFridgeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFridge(UpdatedFridgeViewModel updatedFridge)
        {
            var fridgeProduct = await _fridgeProductsService.GetFridgesProducts();

            foreach (AddProductInFridgeViewModel item in updatedFridge.FridgeProducts)
            {
                if (item.IsChecked)
                {
                    var isExists = fridgeProduct.Any(x => x.FridgeId == updatedFridge.Id && x.ProductId == item.Id);
                    if (isExists)
                        await _fridgeProductsService.DeleteFridgeProduct(fridgeProduct.FirstOrDefault(x => x.FridgeId == updatedFridge.Id && x.ProductId == item.Id).Id);
                    await _fridgeProductsService.AddFridgeProduct(new CreationFridgeProductViewModel()
                    {
                        FridgeId = updatedFridge.Id,
                        ProductId = item.Id,
                        Quantity = item.Quantity
                    });
                }
            }

            //var updatedFridgeProducts = fridgeProduct
            //    .Where(x => x.FridgeId.Equals(updatedFridge.Id) && x.ProductId.Equals(updatedFridge.FridgeProducts.First(i => i.IsChecked == true)))

            var resultViewModel = _mapper.Map<UpdatedShortFridgeViewModel>(updatedFridge);

            await _fridgesService.UpdateFridge(updatedFridge.Id, resultViewModel);
            return RedirectToAction("GetFridges", "Fridges");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            await _fridgesService.DeleteFridge(id);
            return RedirectToAction("GetFridges", "Fridges");
        }

        [HttpGet]
        public IActionResult AddFridge()
        {
            return View(new AddFridgeViewModel());
        }

        [HttpPost]
        public IActionResult AddFridge(AddFridgeViewModel model)
        {
            
            return RedirectToAction("GetFridges", "Fridges");
        }

    }
}
