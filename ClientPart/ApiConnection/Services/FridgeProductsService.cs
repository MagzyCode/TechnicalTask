using ClientPart.ApiConnection.Contracts;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeProductsService : BaseRefitService<IFridgeProductsData>
    {
        public async Task<IEnumerable<FridgeProductsViewModel>> CallServerProcedure(string token) 
            => await _data.CallServerProcedure(token);
        public async Task<FridgeProductsViewModel> GetFridgeProductById(Guid fridgeProductId, string token) 
            => await _data.GetFridgeProductById(fridgeProductId, token);
        public async Task AddFridgeProduct(CreationFridgeProductViewModel creationFridgeProduct, string token) 
            => await _data.AddFridgeProduct(creationFridgeProduct, token);
        public async Task DeleteFridgeProduct(Guid fridgeProductId, string token) 
            => await _data.DeleteFridgeProduct(fridgeProductId, token);
        public async Task<IEnumerable<FridgeProductsViewModel>> GetFridgesProducts(string token) 
            => await _data.GetFridgesProducts(token);

    }
}
