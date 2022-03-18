using ClientPart.ApiConnection.Contracts;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class ProductsService : BaseRefitService<IProductsData>
    {
        public async Task<IEnumerable<ProductsViewModel>> GetProducts() => await _data.GetProducts();

        public Task UpdateProduct(Guid productId, UpdatedProductViewModel product) => _data.UpdateProduct(productId, product);
    }
}
