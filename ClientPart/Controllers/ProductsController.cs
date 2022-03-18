using AutoMapper;
using ClientPart.ApiConnection.Services;
using ClientPart.ViewModels;
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
        private readonly IMapper _mapper;

        public ProductsController(ProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var products = await _productsService.GetProducts();
            var updadtedProduct = products.First(x => x.Id.Equals(id));
            var updatedProductViewModel = _mapper.Map<UpdatedProductViewModel>(updadtedProduct);
            updatedProductViewModel.Id = id;
            return View(updatedProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdatedProductViewModel model)
        {
            if (model == null)
                return BadRequest();
            await _productsService.UpdateProduct(model.Id, model);
            return RedirectToAction("GetProducts", "Products");
        }
    }
}
