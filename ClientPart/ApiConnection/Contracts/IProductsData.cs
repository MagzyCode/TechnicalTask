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
        public Task<IEnumerable<Products>> GetProducts([Authorize("Bearer")] string token);

        [Put("/api/products/{productId}")]
        public Task UpdateProduct(Guid productId, [Body] Products product, [Authorize("Bearer")] string token);
    }
}
