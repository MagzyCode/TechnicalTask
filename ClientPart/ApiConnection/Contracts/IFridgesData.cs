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
        public Task<IEnumerable<FridgesViewModel>> GetAllFridges();

        [Get("/api/fridges/{fridgeId}")]
        public Task<FridgesViewModel> GetFridge(Guid fridgeId);

        [Get("/api/fridges/{fridgeId}/products")]
        public Task<IEnumerable<ProductsViewModel>> GetFridgesProducts(Guid fridgeId);
    }
}
