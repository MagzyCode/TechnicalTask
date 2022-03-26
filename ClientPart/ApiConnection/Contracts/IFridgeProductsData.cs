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
    public interface IFridgeProductsData : IApiData
    {
        [Get("/api/fridgeProducts/procedure")]
        public Task CallServerProcedureAsync();

        [Get("/api/fridgeProducts")]
        public Task<IEnumerable<FridgeProducts>> GetFridgesProductsAsync();

        [Get("/api/fridgeProducts/{fridgeProductId}")]
        public Task<FridgeProducts> GetFridgeProductByIdAsync(Guid fridgeProductId);

        [Post("/api/fridgeProducts")]
        public Task AddFridgeProductAsync([Body] FridgeProducts creationFridgeProduct);

        [Delete("/api/fridgeProducts/{fridgeProductId}")]
        public Task DeleteFridgeProductAsync(Guid fridgeProductId);
    }
}
