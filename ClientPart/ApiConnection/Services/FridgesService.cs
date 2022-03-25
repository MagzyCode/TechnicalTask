using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgesService : BaseRefitService<IFridgesData>
    {
        public FridgesService(IConfiguration configuration) : base(configuration)
        { }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(string token) => await _data.GetAllFridgesAsync(token);

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId, string token) => await _data.GetFridgeAsync(fridgeId, token);

        public async Task<IEnumerable<Products>> GetFridgesProductsAsync(Guid fridgeId, string token) => await _data.GetFridgesProductsAsync(fridgeId, token);

        public async Task UpdateFridgeAsync(Guid fridgeId, Fridge updatedFridge, string token) 
            => await _data.UpdateFridgeAsync(fridgeId, updatedFridge, token);

        public async Task DeleteFridgeAsync(Guid fridgeId, string token) => await _data.DeleteFridgeAsync(fridgeId, token);

        public async Task<Guid> AddFridgeAsync(Fridge model, string token) => await _data.AddFridgeAsync(model, token);
    }
}
