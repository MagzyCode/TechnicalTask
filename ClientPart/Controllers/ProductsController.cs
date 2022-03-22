﻿using AutoMapper;
using ClientPart.ApiConnection.Services;
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
            var token = _authenticationService.GetToken(this);
            var products = await _productsService.GetProducts(token);
            return View(products);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var token = _authenticationService.GetToken(this);
            var products = await _productsService.GetProducts(token);
            var updadtedProduct = products.First(x => x.Id.Equals(id));
            var updatedProductViewModel = _mapper.Map<UpdatedProductViewModel>(updadtedProduct);
            updatedProductViewModel.Id = id;
            return View(updatedProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdatedProductViewModel model)
        {
            var token = _authenticationService.GetToken(this);
            if (model == null)
                return BadRequest();
            await _productsService.UpdateProduct(model.Id, model, token);
            return RedirectToAction("GetProducts", "Products");
        }
    }
}
