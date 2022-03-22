using ClientPart.ApiConnection.Contracts;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeModelService : BaseRefitService<IFridgeModelData>
    {
        public async Task<IEnumerable<FridgeModelViewModel>> GetFridgeModels(string token) => await _data.GetFridgeModels(token);
        public async Task<FridgeModelViewModel> GetFridgeModel(Guid fridgeModelId, string token) => await _data.GetFridgeModel(fridgeModelId, token);
    }
}
