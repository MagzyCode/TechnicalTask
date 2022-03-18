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
        public async Task<IEnumerable<FridgeProductsViewModel>> CallServerProcedure() => await _data.CallServerProcedure();
        public async Task<FridgeProductsViewModel> GetFridgeProductById(Guid fridgeProductId) => await _data.GetFridgeProductById(fridgeProductId);
        public async Task AddFridgeProduct(CreationFridgeProductViewModel creationFridgeProduct) => await _data.AddFridgeProduct(creationFridgeProduct);
        public async Task DeleteFridgeProduct(Guid fridgeProductId) => await _data.DeleteFridgeProduct(fridgeProductId);
        public async Task<IEnumerable<FridgeProductsViewModel>> GetFridgesProducts() => await _data.GetFridgesProducts();

    }
}
