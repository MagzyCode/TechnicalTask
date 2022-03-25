using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class ProductsService : BaseRefitService<IProductsData>
    {
        public ProductsService(IConfiguration configuration) : base(configuration)
        { }

        public async Task<IEnumerable<Products>> GetProductsAsync(string token) => await _data.GetProductsAsync(token);

        public Task UpdateProductAsync(Guid productId, Products product, string token) => _data.UpdateProductAsync(productId, product, token);
    }
}
