using AutoMapper;
using ClientPart.ApiConnection.Services;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Controllers
{
    [Authorize]
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
            var products = await _productsService.GetProductsAsync();
            var productsViewModel = _mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return View(productsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var updatedProduct = await _productsService.GetProductAsync(id);
            var updatedProductViewModel = _mapper.Map<UpdatedProductViewModel>(updatedProduct);

            return View(updatedProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdatedProductViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            var imageInBytes = Array.Empty<byte>();
            using (var binaryReader = new BinaryReader(model.ImageData.OpenReadStream()))
            {
                imageInBytes = binaryReader.ReadBytes((int)model.ImageData.Length);
            }

            var updatedProduct = _mapper.Map<Products>(model);
            updatedProduct.Image = imageInBytes;

            await _productsService.UpdateProductAsync(updatedProduct.Id, updatedProduct);

            return RedirectToAction("GetProducts", "Products");
        }
    }
}
