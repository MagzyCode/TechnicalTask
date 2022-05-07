using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class ProductsService : BaseRefitService<IProductsData>
    {
        public ProductsService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService)
            : base(configuration, httpContextAccessor, authenticationService)
        { }

        public async Task<IEnumerable<Products>> GetProductsAsync() => await _data.GetProductsAsync();

        public async Task UpdateProductAsync(Guid productId, Products product) => await _data.UpdateProductAsync(productId, product);

        public async Task<Products> GetProductAsync(Guid productId) => await _data.GetProductAsync(productId);
    }
}
