using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgesService : BaseRefitService<IFridgesData>
    {
        public FridgesService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService)
            : base(configuration, httpContextAccessor, authenticationService)
        { }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync() => await _data.GetAllFridgesAsync();

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId) => await _data.GetFridgeAsync(fridgeId);

        public async Task<IEnumerable<Products>> GetFridgesProductsAsync(Guid fridgeId) => await _data.GetFridgesProductsAsync(fridgeId);

        public async Task UpdateFridgeAsync(Guid fridgeId, Fridge updatedFridge) 
            => await _data.UpdateFridgeAsync(fridgeId, updatedFridge);

        public async Task DeleteFridgeAsync(Guid fridgeId) => await _data.DeleteFridgeAsync(fridgeId);

        public async Task<Guid> AddFridgeAsync(Fridge model) => await _data.AddFridgeAsync(model);
    }
}
