using ClientPart.Models;
using ClientPart.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IFridgeModelData : IApiData
    {
        [Get("/api/fridgeModels")]
        public Task<IEnumerable<FridgeModel>> GetFridgeModels([Authorize("Bearer")] string token);

        [Get("/api/fridgeModels/{fridgeModelId}")]
        public Task<FridgeModel> GetFridgeModel(Guid fridgeModelId, [Authorize("Bearer")] string token);
    }
}
