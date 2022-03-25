using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeProductsService : BaseRefitService<IFridgeProductsData>
    {
        public async Task CallServerProcedure() => await _data.CallServerProcedure();
        public async Task<FridgeProductsViewModel> GetFridgeProductById(Guid fridgeProductId, string token) 
            => await _data.GetFridgeProductById(fridgeProductId, token);
        public async Task AddFridgeProduct(FridgeProducts creationFridgeProduct, string token) 
            => await _data.AddFridgeProduct(creationFridgeProduct, token);
        public async Task DeleteFridgeProduct(Guid fridgeProductId, string token) 
            => await _data.DeleteFridgeProduct(fridgeProductId, token);
        public async Task<IEnumerable<FridgeProducts>> GetFridgesProducts(string token) 
            => await _data.GetFridgesProducts(token);

    }
}
