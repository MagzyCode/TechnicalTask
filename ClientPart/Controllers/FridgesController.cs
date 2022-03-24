using ClientPart.ApiConnection.Services;
using ClientPart.ViewModels;
using ClientPart.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ClientPart.Controllers
{
    public class FridgesController : Controller
    {
        private readonly FridgesService _fridgesService;
        private readonly FridgeModelService _fridgeModelService;
        private readonly ProductsService _productsService;
        private readonly FridgeProductsService _fridgeProductsService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public FridgesController(
            FridgesService fridgesService, 
            FridgeModelService modelService, 
            ProductsService productsService,
            FridgeProductsService fridgeProductsService,
            AuthenticationService authenticationService,
            IMapper mapper)
        {
            _fridgesService = fridgesService;
            _mapper = mapper;
            _fridgeModelService = modelService;
            _productsService = productsService;
            _fridgeProductsService = fridgeProductsService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFridges()
        {
            try
            {
                var fridges = await _fridgesService.GetAllFridges(_authenticationService.GetToken(this));
                return View(fridges);
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You should sign in.";
                return View("~/Views/Home/Error.cshtml");
            }
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateFridge(Guid id)
        {
            var token = _authenticationService.GetToken(this);
            var updatedFridge = await _fridgesService.GetFridge(id, token);
            var updatedFridgeViewModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            updatedFridgeViewModel.Controller = this;
            var fridgeProducts = await _fridgeProductsService.GetFridgesProducts(token);
            var fridgeProductsById = fridgeProducts
                .Where(x => x.FridgeId.Equals(id))
                .ToList();
            var products = await _productsService.GetProducts(token);
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
        [Authorize]
        public async Task<IActionResult> UpdateFridge(UpdatedFridgeViewModel updatedFridge)
        {
            try
            {
                var token = _authenticationService.GetToken(this);
                var fridgeProduct = await _fridgeProductsService.GetFridgesProducts(token);

                foreach (AddProductInFridgeViewModel item in updatedFridge.FridgeProducts)
                {
                    if (item.IsChecked)
                    {
                        var isExists = fridgeProduct.Any(x => x.FridgeId == updatedFridge.Id && x.ProductId == item.Id);
                        if (isExists)
                            await _fridgeProductsService.DeleteFridgeProduct(
                                fridgeProduct.FirstOrDefault(x => x.FridgeId == updatedFridge.Id && x.ProductId == item.Id).Id
                                , token);
                        await _fridgeProductsService.AddFridgeProduct(new CreationFridgeProductViewModel()
                        {
                            FridgeId = updatedFridge.Id,
                            ProductId = item.Id,
                            Quantity = item.Quantity
                        }
                        , token);
                    }
                }

                var resultViewModel = _mapper.Map<UpdatedShortFridgeViewModel>(updatedFridge);

                await _fridgesService.UpdateFridge(updatedFridge.Id, resultViewModel, token);
                return RedirectToAction("GetFridges", "Fridges");
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You have no access to this option";
                return View("~/Views/Home/Error.cshtml");
            }
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            try
            {
                var token = _authenticationService.GetToken(this);
                await _fridgesService.DeleteFridge(id, token);
                return RedirectToAction("GetFridges", "Fridges");
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You have no access to this option";
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddFridge()
        {
            var token = _authenticationService.GetToken(this);
            var products = await _productsService.GetProducts(token);
            var productsViewModel = _mapper.Map<IEnumerable<AddProductInFridgeViewModel>>(products)
                .ToList();
            var fridgeModels = await _fridgeModelService.GetFridgeModels(token);
            var fridgeModelsDto = _mapper.Map<IEnumerable<FridgeModelViewModel>>(fridgeModels)
                .ToList();

            return View(new AddFridgeViewModel() 
            { 
                FridgeProducts = productsViewModel,
                FridgeModels = fridgeModelsDto
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFridge(AddFridgeViewModel model)
        {
            var token = _authenticationService.GetToken(this);

            if (!ModelState.IsValid)
                return BadRequest();

            if (model == null)
                return NotFound();

            var addModel = _mapper.Map<AddShortFridgeViewModel>(model);
            try
            {
                var createdGuid = await _fridgesService.AddFridge(addModel, token);

                foreach (AddProductInFridgeViewModel item in model.FridgeProducts)
                {
                    if (item.IsChecked)
                    {
                        await _fridgeProductsService.AddFridgeProduct(new CreationFridgeProductViewModel()
                        {
                            FridgeId = createdGuid,
                            ProductId = item.Id,
                            Quantity = item.Quantity
                        },
                        token: token);
                    }

                }
                return RedirectToAction("GetFridges", "Fridges");
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You have no access to this option";
                return View("~/Views/Home/Error.cshtml");
            }
            
        }

    }

    
}
