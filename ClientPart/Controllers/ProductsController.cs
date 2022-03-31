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
            var products = await _productsService.GetProductsAsync();
            var productsViewModel = _mapper.Map<IEnumerable<ProductsViewModel>>(products);

            foreach (var product in productsViewModel)
            {
                if (product.Image != null)
                    product.ImageSrc = Convert.ToBase64String(product.Image);
            }

            return View(productsViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var products = await _productsService.GetProductsAsync();
            var updatedProduct = products.First(x => x.Id == id);

            var updatedProductViewModel = _mapper.Map<UpdatedProductViewModel>(updatedProduct);

            return View(updatedProductViewModel);
        }

        [HttpPost]
        [Authorize]
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
