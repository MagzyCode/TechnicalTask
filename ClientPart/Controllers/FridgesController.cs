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
            var fridges = await _fridgesService.GetAllFridges(_authenticationService.GetToken(this));
            return View(fridges);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateFridge(Guid id)
        {
            var token = _authenticationService.GetToken(this);
            var updatedFridge = await _fridgesService.GetFridge(id, token);
            var updatedFridgeViewModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            // all
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

            //var updatedFridgeProducts = fridgeProduct
            //    .Where(x => x.FridgeId.Equals(updatedFridge.Id) && x.ProductId.Equals(updatedFridge.FridgeProducts.First(i => i.IsChecked == true)))

            var resultViewModel = _mapper.Map<UpdatedShortFridgeViewModel>(updatedFridge);

            await _fridgesService.UpdateFridge(updatedFridge.Id, resultViewModel, token);
            return RedirectToAction("GetFridges", "Fridges");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            var token = _authenticationService.GetToken(this);
            await _fridgesService.DeleteFridge(id, token);
            return RedirectToAction("GetFridges", "Fridges");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddFridge()
        {
            var token = _authenticationService.GetToken(this);

            //var updatedFridge = await _fridgesService.GetFridge(id);
            //var updatedFridgeViewModel = _mapper.Map<UpdatedFridgeViewModel>(updatedFridge);
            // all
            //var fridgeProducts = await _fridgeProductsService.GetFridgesProducts();
            var products = await _productsService.GetProducts(token);
            var productsViewModel = _mapper.Map<IEnumerable<AddProductInFridgeViewModel>>(products);
            //foreach (AddProductInFridgeViewModel item in productsViewModel)
            //{
            //    if (fridgeProductsById.Any(x => x.ProductId.Equals(item.Id)))
            //    {
            //        item.IsChecked = true;
            //        item.Quantity = fridgeProductsById.First(x => x.ProductId.Equals(item.Id)).Quantity;
            //    }
            //}
            //updatedFridgeViewModel.FridgeProducts = productsViewModel.ToList();
            //return View(updatedFridgeViewModel);


            return View(new AddFridgeViewModel() 
            { 
                FridgeProducts = productsViewModel.ToList(),
                Controller = this
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFridge(AddFridgeViewModel model)
        {
            var token = _authenticationService.GetToken(this);

            if (model == null)
                return NotFound();

            var addModel = _mapper.Map<AddShortFridgeViewModel>(model);
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
                    token : token);
                }

            }
            return RedirectToAction("GetFridges", "Fridges");
        }

    }

    
}
