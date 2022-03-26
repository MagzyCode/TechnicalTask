using AutoMapper;
using ClientPart.ApiConnection.Services;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly AuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public ProductsController(ProductsService productsService, AuthenticationService authenticationServic, IMapper mapper)
        {
            _productsService = productsService;
            _authenticationService = authenticationServic;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var token = _authenticationService.GetToken(this);
                var products = await _productsService.GetProductsAsync();
                var productsViewModel = _mapper.Map<IEnumerable<ProductsViewModel>>(products);

                return View(productsViewModel);
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You should sign in.";
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var token = _authenticationService.GetToken(this);

            var products = await _productsService.GetProductsAsync();
            var updatedProduct = products.First(x => x.Id.Equals(id));
            var updatedProductViewModel = _mapper.Map<UpdatedProductViewModel>(updatedProduct);

            return View(updatedProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdatedProductViewModel model)
        {
            try
            {
                var token = _authenticationService.GetToken(this);

                if (model == null || !ModelState.IsValid)
                    return BadRequest();

                var updatedProduct = _mapper.Map<Products>(model);
                await _productsService.UpdateProductAsync(updatedProduct.Id, updatedProduct);

                return RedirectToAction("GetProducts", "Products");
            }
            catch (Refit.ApiException)
            {
                ViewData["Error"] = "You have no access to this option";
                return View("~/Views/Home/Error.cshtml");
            }
        }
    }
}
