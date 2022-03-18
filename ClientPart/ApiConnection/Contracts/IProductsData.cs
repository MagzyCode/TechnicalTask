using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IProductsData : IApiData
    {
        [Get("/api/products")]
        //[Headers("Authorization: Bearer")]
        public Task<IEnumerable<ProductsViewModel>> GetProducts();

        [Put("/api/products/{productId}")]
        //[Headers("Authorization: Bearer")]
        public Task UpdateProduct(Guid productId, [Body] UpdatedProductViewModel product);
    }
}
