using ClientPart.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IFridgeModelData : IApiData
    {
        [Get("/api/fridgeModels")]
        public Task<IEnumerable<FridgeModel>> GetFridgeModelsAsync();

        [Get("/api/fridgeModels/{fridgeModelId}")]
        public Task<FridgeModel> GetFridgeModelAsync(Guid fridgeModelId);
    }
}
