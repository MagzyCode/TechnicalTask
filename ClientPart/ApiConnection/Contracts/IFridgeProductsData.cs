using ClientPart.Models;
using Refit;
using System;
using System.Collections.Generic;
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

        [Put("/api/fridgeProducts/{fridgeProductId}")]
        public Task UpdateFridgeProductAsync(Guid fridgeProductId, [Body] FridgeProducts updateFridgeProduct);
    }
}
