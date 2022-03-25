using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IFridgesData : IApiData
    {
        [Get("/api/fridges")]
        public Task<IEnumerable<Fridge>> GetAllFridges([Authorize("Bearer")] string token);

        [Get("/api/fridges/{fridgeId}")]
        public Task<Fridge> GetFridge(Guid fridgeId, [Authorize("Bearer")] string token);

        [Get("/api/fridges/{fridgeId}/products")]
        public Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId, [Authorize("Bearer")] string token);

        [Put("/api/fridges/{fridgeId}")]
        public Task UpdateFridge(Guid fridgeId, [Body] Fridge updatedFridge, [Authorize("Bearer")] string token);

        [Delete("/api/fridges/{fridgeId}")]
        public Task DeleteFridge(Guid fridgeId, [Authorize("Bearer")] string token);

        [Post("/api/fridges")]
        public Task<Guid> AddFridge([Body] Fridge model, [Authorize("Bearer")] string token);
    }
}
