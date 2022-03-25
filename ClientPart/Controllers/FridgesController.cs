﻿using ClientPart.ApiConnection.Services;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ClientPart.Models;

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
                var fridges = await _fridgesService.GetAllFridgesAsync(_authenticationService.GetToken(this));
                var fridgesViewModel = _mapper.Map<IEnumerable<FridgesViewModel>>(fridges);

                return View(fridgesViewModel);
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

            var updatedFridge = await _fridgesService.GetFridgeAsync(id, token);
            var fridgeModels = await _fridgeModelService.GetFridgeModelsAsync(token);

            var fridgeModelsViewModel = _mapper.Map<IEnumerable<FridgeModelViewModel>>(fridgeModels);
            var updatedFridgeViewModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            updatedFridgeViewModel.FridgeModels = fridgeModelsViewModel.ToList();
             
            var fridgeProducts = await _fridgeProductsService.GetFridgesProductsAsync(token);
            var fridgeProductsViewModel = _mapper.Map<IEnumerable<FridgeProductsViewModel>>(fridgeProducts);

            var productsOfCurrentFridge = fridgeProductsViewModel
                .Where(x => x.FridgeId.Equals(id))
                .ToList();
            
            var products = await _productsService.GetProductsAsync(token);
            var productsViewModel = _mapper.Map<IEnumerable<AddProductInFridgeViewModel>>(products);

            foreach (AddProductInFridgeViewModel item in productsViewModel)
            {
                if (productsOfCurrentFridge.Any(x => x.ProductId.Equals(item.Id)))
                {
                    item.IsChecked = true;
                    item.Quantity = productsOfCurrentFridge.First(x => x.ProductId.Equals(item.Id)).Quantity;
                }
            }
            
            updatedFridgeViewModel.FridgeProducts = productsViewModel.ToList();
            return View(updatedFridgeViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateFridge(UpdatedFridgeViewModel updatedFridgeViewModel)
        {
            try
            {
                var token = _authenticationService.GetToken(this);
                var fridgeProduct = await _fridgeProductsService.GetFridgesProductsAsync(token);

                foreach (AddProductInFridgeViewModel item in updatedFridgeViewModel.FridgeProducts)
                {
                    if (item.IsChecked)
                    {
                        var isExists = fridgeProduct.Any(x => x.FridgeId == updatedFridgeViewModel.Id && x.ProductId == item.Id);

                        if (isExists)
                        {
                            await _fridgeProductsService.DeleteFridgeProductAsync(
                                fridgeProductId: fridgeProduct
                                    .FirstOrDefault(x => x.FridgeId == updatedFridgeViewModel.Id && x.ProductId == item.Id)
                                    .Id,
                                token: token);
                        }
                            
                        await _fridgeProductsService.AddFridgeProductAsync(
                            creationFridgeProduct : new FridgeProducts()
                            {
                                FridgeId = updatedFridgeViewModel.Id,
                                ProductId = item.Id,
                                Quantity = item.Quantity
                            },
                            token : token);
                    }
                }

                var updatedFridge = _mapper.Map<Fridge>(updatedFridgeViewModel);

                await _fridgesService.UpdateFridgeAsync(updatedFridgeViewModel.Id, updatedFridge, token);

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
                await _fridgesService.DeleteFridgeAsync(id, token);

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

            var products = await _productsService.GetProductsAsync(token);
            var productsViewModel = _mapper.Map<IEnumerable<AddProductInFridgeViewModel>>(products)
                .ToList();

            var fridgeModels = await _fridgeModelService.GetFridgeModelsAsync(token);
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

            if (!ModelState.IsValid || model == null)
                return BadRequest();

            var addingFridge = _mapper.Map<Fridge>(model);
            try
            {
                var createdGuid = await _fridgesService.AddFridgeAsync(addingFridge, token);

                foreach (AddProductInFridgeViewModel item in model.FridgeProducts)
                {
                    if (item.IsChecked)
                    {
                        await _fridgeProductsService.AddFridgeProductAsync(
                            creationFridgeProduct : new FridgeProducts()
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
