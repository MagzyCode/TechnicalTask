using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
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
        public async Task<IEnumerable<Fridge>> GetAllFridges(string token) => await _data.GetAllFridges(token);

        public async Task<Fridge> GetFridge(Guid fridgeId, string token) => await _data.GetFridge(fridgeId, token);

        public async Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId, string token) => await _data.GetFridgesProducts(fridgeId, token);

        public async Task UpdateFridge(Guid fridgeId, Fridge updatedFridge, string token) 
            => await _data.UpdateFridge(fridgeId, updatedFridge, token);

        public async Task DeleteFridge(Guid fridgeId, string token) => await _data.DeleteFridge(fridgeId, token);

        public async Task<Guid> AddFridge(Fridge model, string token) => await _data.AddFridge(model, token);
    }
}
