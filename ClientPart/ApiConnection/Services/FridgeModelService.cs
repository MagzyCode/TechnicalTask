using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeModelService : BaseRefitService<IFridgeModelData>
    {
        public async Task<IEnumerable<FridgeModel>> GetFridgeModels(string token) => await _data.GetFridgeModels(token);
        public async Task<FridgeModel> GetFridgeModel(Guid fridgeModelId, string token) => await _data.GetFridgeModel(fridgeModelId, token);
    }
}
