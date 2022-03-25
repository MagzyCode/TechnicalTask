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
        public Task<IEnumerable<Fridge>> GetAllFridgesAsync([Authorize("Bearer")] string token);

        [Get("/api/fridges/{fridgeId}")]
        public Task<Fridge> GetFridgeAsync(Guid fridgeId, [Authorize("Bearer")] string token);

        [Get("/api/fridges/{fridgeId}/products")]
        public Task<IEnumerable<Products>> GetFridgesProductsAsync(Guid fridgeId, [Authorize("Bearer")] string token);

        [Put("/api/fridges/{fridgeId}")]
        public Task UpdateFridgeAsync(Guid fridgeId, [Body] Fridge updatedFridge, [Authorize("Bearer")] string token);

        [Delete("/api/fridges/{fridgeId}")]
        public Task DeleteFridgeAsync(Guid fridgeId, [Authorize("Bearer")] string token);

        [Post("/api/fridges")]
        public Task<Guid> AddFridgeAsync([Body] Fridge model, [Authorize("Bearer")] string token);
    }
}
