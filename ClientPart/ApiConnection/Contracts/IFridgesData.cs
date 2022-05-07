using ClientPart.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IFridgesData : IApiData
    {
        [Get("/api/fridges")]
        public Task<IEnumerable<Fridge>> GetAllFridgesAsync();

        [Get("/api/fridges/{fridgeId}")]
        public Task<Fridge> GetFridgeAsync(Guid fridgeId);

        [Get("/api/fridges/{fridgeId}/products")]       
        public Task<IEnumerable<Products>> GetFridgesProductsAsync(Guid fridgeId);

        [Put("/api/fridges/{fridgeId}")]
        public Task UpdateFridgeAsync(Guid fridgeId, [Body] Fridge updatedFridge);

        [Delete("/api/fridges/{fridgeId}")]
        public Task DeleteFridgeAsync(Guid fridgeId);

        [Post("/api/fridges")]
        public Task<Guid> AddFridgeAsync([Body] Fridge model);
    }
}
