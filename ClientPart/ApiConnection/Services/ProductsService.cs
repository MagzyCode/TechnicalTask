using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class ProductsService : BaseRefitService<IProductsData>
    {
        public async Task<IEnumerable<Products>> GetProducts(string token) => await _data.GetProducts(token);

        public Task UpdateProduct(Guid productId, Products product, string token) => _data.UpdateProduct(productId, product, token);
    }
}
