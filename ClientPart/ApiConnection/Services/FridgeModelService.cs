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
        public async Task<IEnumerable<FridgeModelViewModel>> GetFridgeModels() => await _data.GetFridgeModels();
        public async Task<FridgeModelViewModel> GetFridgeModel(Guid fridgeModelId) => await _data.GetFridgeModel(fridgeModelId);
    }
}
