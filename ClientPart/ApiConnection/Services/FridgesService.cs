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

        public async Task<FridgesViewModel> GetFridge(Guid fridgeId) => await GetFridge(fridgeId);

        public async Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId) => await _data.GetFridgesProducts(fridgeId);
    }
}
