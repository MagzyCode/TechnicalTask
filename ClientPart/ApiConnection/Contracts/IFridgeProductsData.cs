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
        public Task CallServerProcedure();

        [Get("/api/fridgeProducts")]
        public Task<IEnumerable<FridgeProducts>> GetFridgesProducts([Authorize("Bearer")] string token);

        [Get("/api/fridgeProducts/{fridgeProductId}")]
        public Task<FridgeProductsViewModel> GetFridgeProductById(Guid fridgeProductId, [Authorize("Bearer")] string token);

        [Post("/api/fridgeProducts")]
        public Task AddFridgeProduct([Body] FridgeProducts creationFridgeProduct, [Authorize("Bearer")] string token);

        [Delete("/api/fridgeProducts/{fridgeProductId}")]
        public Task DeleteFridgeProduct(Guid fridgeProductId, [Authorize("Bearer")] string token);
    }
}
