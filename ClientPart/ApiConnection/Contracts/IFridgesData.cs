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
        // [Headers("Authorization: Bearer")]
        public Task<IEnumerable<FridgesViewModel>> GetAllFridges();

        [Get("/api/fridges/{fridgeId}")]
        // [Headers("Authorization: Bearer")]
        public Task<FridgesViewModel> GetFridge(Guid fridgeId);

        [Get("/api/fridges/{fridgeId}/products")]
        // [Headers("Authorization: Bearer")]
        public Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId);

        [Put("/api/fridges/{fridgeId}")]
        // [Headers("Authorization: Bearer")]
        public Task UpdateFridge(Guid fridgeId, [Body] UpdatedFridgeViewModel updatedFridge);

        [Delete("/api/fridges/{fridgeId}")]
        public Task DeleteFridge(Guid fridgeId);
    }
}
