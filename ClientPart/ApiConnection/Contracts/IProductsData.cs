using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientPart.Models;
using Refit;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IProductsData : IApiData
    {
        [Get("/api/products")]
        public Task<IEnumerable<Products>> GetProductsAsync();

        [Put("/api/products/{productId}")]
        public Task UpdateProductAsync(Guid productId, [Body] Products product);

        [Get("/api/products/{productId}")]
        public Task<Products> GetProductAsync(Guid productId);
    }
}
