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
        public Task<IEnumerable<FridgeModelViewModel>> GetFridgeModels();

        [Get("/api/fridgeModels/{fridgeModelId}")]
        public Task<FridgeModelViewModel> GetFridgeModel(Guid fridgeModelId);
    }
}
