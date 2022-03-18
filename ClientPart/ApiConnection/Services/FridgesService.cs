using ClientPart.ApiConnection.Contracts;
using ClientPart.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgesService : BaseRefitService<IFridgesData>
    {
        public async Task<IEnumerable<FridgesViewModel>> GetAllFridges() => await _data.GetAllFridges();

        public async Task<FridgesViewModel> GetFridge(Guid fridgeId) => await _data.GetFridge(fridgeId);

        public async Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId) => await _data.GetFridgesProducts(fridgeId);

        public async Task UpdateFridge(Guid fridgeId, UpdatedShortFridgeViewModel updatedFridge) => await _data.UpdateFridge(fridgeId, updatedFridge);

        public async Task DeleteFridge(Guid fridgeId) => await _data.DeleteFridge(fridgeId);
    }
}
